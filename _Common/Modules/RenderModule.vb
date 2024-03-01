Option Explicit On
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices

Module RenderModule

#Region "Declarations"
    Public RefreshLock As Boolean = False ' Global disable bitmap refresh to PictureBox when set.

    ' Since module is shared, it needs its own variable for adjustment
    Public RenderModuleArrayAdjuster As Integer = -1

    Public Structure BITMAPINFOHEADER
        Dim biSize As Integer
        Dim biWidth As Integer
        Dim biHeight As Integer
        Dim biPlanes As Short
        Dim biBitCount As Short
        Dim biCompression As Integer
        Dim biSizeImage As Integer
        Dim biXPelsPerMeter As Integer
        Dim biYPelsPerMeter As Integer
        Dim biClrUsed As Integer
        Dim biClrImportant As Integer
    End Structure

    Public Structure Bmbuffer
        Dim SX As Integer
        Dim SY As Integer
        Dim data() As Byte
    End Structure

    Public Class BITMAPINFO
        Public Header As BITMAPINFOHEADER
        Public bytesRGB_UpdatedSinceLastRender As Boolean = False
        Public palette_UpdatedSinceLastBytesRGB_Update As Boolean = False
        Public pal(255) As Integer
        Public bytesRGB_ByPixelID() As Integer ' Contain an actual color (not the palette) for each pixel
        Public bytesPal_ByPixelID() As Integer ' Contain for each pixel the PalID from pal

        Public Sub Initialize()
            ReDim pal(255)
        End Sub

        Public Sub RedimPixelBytes(qtyPixel As Integer)
            ReDim bytesRGB_ByPixelID(qtyPixel - 1)
            ReDim bytesPal_ByPixelID(qtyPixel - 1)
        End Sub

        ' Used when palette was Updated (but not image), need to reupdate bytesRGB
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub UpdateBytesRGB_FromBytesPal()
            Dim i As Integer
            Dim iMax As Integer = bytesRGB_ByPixelID.Length - 1

            For i = 0 To iMax
                bytesRGB_ByPixelID(i) = pal(bytesPal_ByPixelID(i))
            Next
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub PalIDSave(pixelFirstPos As Integer, palID As Integer)
            bytesPal_ByPixelID(pixelFirstPos) = palID
            bytesRGB_ByPixelID(pixelFirstPos) = pal(palID)
        End Sub
    End Class

#End Region

#Region "Functions"
    Public Sub PB_Init(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        Dim WidthOf, HeightOf As Integer

        If TilePB.Image Is Nothing Then TilePB.Image = New Bitmap(TilePB.Width, TilePB.Height)
        If bmix Is Nothing Then bmix = New BITMAPINFO()

        WidthOf = TilePB.Width
        HeightOf = TilePB.Height
        With bmix.Header
            .biSize = 40
            .biWidth = WidthOf
            .biHeight = -HeightOf
            .biPlanes = 1
            .biBitCount = 8
            .biSizeImage = WidthOf * HeightOf
            .biClrUsed = 256
        End With
        bmix.RedimPixelBytes(bmix.Header.biSizeImage)
    End Sub

    Public Sub PB_ReSizeInit(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        Dim WidthOf, HeightOf As Integer
        WidthOf = TilePB.Width
        HeightOf = TilePB.Height
        With bmix.Header
            .biWidth = WidthOf
            .biHeight = -HeightOf
            .biSizeImage = WidthOf * HeightOf
        End With
        bmix.RedimPixelBytes(bmix.Header.biSizeImage)
    End Sub

    Public Function ExtractRegionFromBitmap(bmpSrc As Bitmap, x1 As Integer, width As Integer, y1 As Integer, height As Integer) As Bitmap
        ' Create a new bitmap to hold the extracted region
        ExtractRegionFromBitmap = New Bitmap(width, height)

        ' Create a graphics object from the extracted bitmap
        Using g As Graphics = Graphics.FromImage(ExtractRegionFromBitmap)
            ' Set the clipping region to the specified rectangle
            g.SetClip(New Rectangle(0, 0, width, height))

            ' Draw the specified region onto the extracted bitmap
            g.DrawImage(bmpSrc, -x1, -y1)
        End Using
    End Function

    Public Sub RenderPic(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        If RefreshLock = True Then Exit Sub

        RenderPicAlwaysIfItWasChangedSinceLastupdate(TilePB, bmix)
    End Sub

    Public Sub RenderPicEvenIfNoChange(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        ' Create a compatible Bitmap object based on bmix dimensions
        '   (will need to be scaled for actual PictureBox if needed)
        Dim bmpSrc As New Bitmap(bmix.Header.biWidth, -bmix.Header.biHeight, PixelFormat.Format32bppRgb)
        Dim bmpDest As New Bitmap(TilePB.Width, TilePB.Height, PixelFormat.Format32bppRgb)
        Dim bmpData As BitmapData = bmpSrc.LockBits(New Rectangle(0, 0, bmpSrc.Width, bmpSrc.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb)

        ' Copy all bytes to bitmap
        Runtime.InteropServices.Marshal.Copy(bmix.bytesRGB_ByPixelID, 0, bmpData.Scan0, bmix.bytesRGB_ByPixelID.Length)

        ' Unlock
        bmpSrc.UnlockBits(bmpData)

        If (bmpSrc.Width = bmpDest.Width And bmpSrc.Height = bmpDest.Height) Then
            ' Assign the bitmap to the PictureBox's Image property
            TilePB.Image = bmpSrc
        Else
            ' Image will need to be scaled
            bmpDest = New Bitmap(bmpSrc, bmpDest.Width, bmpDest.Height)
            ' Assign the bitmap to the PictureBox's Image property
            TilePB.Image = bmpDest
        End If

        TilePB.Refresh()
    End Sub

    Public Sub RenderPicAlwaysIfItWasChangedSinceLastupdate(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        ' To save time, ensure picture pixels need an update
        If bmix.bytesRGB_UpdatedSinceLastRender = False And bmix.palette_UpdatedSinceLastBytesRGB_Update = False Then Exit Sub

        ' If palette was Updated, need to reupdate bytesRGB
        '   If some pixels were updated, unless all of them were, some pixels will still need tu be updated
        If bmix.palette_UpdatedSinceLastBytesRGB_Update = True Then
            bmix.UpdateBytesRGB_FromBytesPal()
        End If

        bmix.bytesRGB_UpdatedSinceLastRender = False
        bmix.palette_UpdatedSinceLastBytesRGB_Update = False

        RenderPicEvenIfNoChange(TilePB, bmix)
    End Sub

    Public Sub DrawPixel(ByRef bmix As BITMAPINFO, x As Integer, y As Integer, palID As Byte)
        Dim height, width, pos As Integer
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        pos = ((y * width) + x)
        If pos < (width * height) And pos > -1 Then
            bmix.PalIDSave(pos, palID)
        End If
    End Sub

    Public Sub DrawLineH(ByRef bmix As BITMAPINFO, x1 As Integer, x2 As Integer, y As Integer, palID As Byte)
        Dim rowbytebase, width, a, height As Integer
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        rowbytebase = (y * width)
        For a = x1 To x2
            'See DrawRectangle for explanation of this
            If (rowbytebase + a) < (width * height) And (rowbytebase + a) > -1 Then
                bmix.PalIDSave((rowbytebase + a), palID)
            End If
        Next a
    End Sub

    Public Sub DrawLineHUsingWxH(ByRef bmix As BITMAPINFO, x As Integer, y As Integer, width As Integer, palID As Integer)
        ' Need to do that so 0 is considered 0
        width -= 1
        If (width < 0) Then Exit Sub
        Dim x2 As Integer = x + width

        DrawLineH(bmix, x, x2, y, palID)
    End Sub

    Public Sub DrawLineV(ByRef bmix As BITMAPINFO, x As Integer, y1 As Integer, y2 As Integer, palID As Byte)
        Dim a, width, height As Integer
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        For a = y1 To y2
            'See DrawRectangle for explanation of this
            If ((a * width) + x) < (width * height) And ((a * width) + x) > -1 Then
                bmix.PalIDSave((a * width) + x, palID)
            End If
        Next a
    End Sub

    Public Sub DrawLineVUsingWxH(ByRef bmix As BITMAPINFO, x As Integer, y As Integer, height As Integer, palID As Integer)
        ' Need to do that so 0 is considered 0
        height -= 1
        If (height < 0) Then Exit Sub
        Dim y2 As Integer = y + height

        DrawLineV(bmix, x, y, y2, palID)
    End Sub

    Public Sub DrawRectangle(ByRef bmix As BITMAPINFO, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, palID As Integer)
        Dim x, y As Integer
        Dim height, width, rowbytebase As Integer
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        For y = y1 To y2
            ' Variables take value of first point to color on current line
            rowbytebase = (y * width)
            For x = x1 To x2
                ' Explanation of following If
                '   (rowbytebase + x) < (width * height)
                '       (rowbytebase + x) = current position to color
                '           This parts checks if not out of bound - Should never happen unless programmer pass
                '           out of bounds limits for drawing zone
                '   This: (rowbytebase + x) > -1 ensures drawing position is bigger than 0
                '   So as a summary, those conditions ensure we are not out of bound of drawing zone
                If (rowbytebase + x) < (width * height) And (rowbytebase + x) > -1 Then
                    bmix.PalIDSave(rowbytebase + x, palID)
                End If
            Next x
        Next y
    End Sub

    Public Sub DrawRectangleUsingWxH(ByRef bmix As BITMAPINFO, x1 As Integer, y1 As Integer, width As Integer, height As Integer, palID As Integer)
        ' Need to do that so 0 is considered 0
        width -= 1
        height -= 1
        If (height < 0 Or height < 0) Then Exit Sub
        Dim x2 As Integer = x1 + width
        Dim y2 As Integer = y1 + height

        DrawRectangle(bmix, x1, y1, x2, y2, palID)
    End Sub

    Public Sub DrawTile(ByRef bmix As BITMAPINFO, Tileoffs As Single, tilepal As Integer, x As Integer, y As Integer, container As Byte(), Optional Multiply As Integer = 1)
        If Tileoffs < 0 Or Tileoffs > (UBound(container) - &HFS) Then Exit Sub

        Dim width, height As Integer
        Dim tileX, tileY As Integer
        Dim X1, X2 As Integer
        Dim i, j, jMax, k, kMax As Integer
        Dim paloffs As Integer
        Dim bmp_nexttileYbytes As Integer
        Dim palID As Integer

        jMax = Multiply - 1
        kMax = jMax
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        paloffs = (tilepal * 4)
        bmp_nexttileYbytes = (width - 8) * Multiply

        i = (y * width) + x
        For tileY = 0 To 7
            X1 = container(RenderModuleArrayAdjuster + Tileoffs + tileY + 1)
            X2 = container(RenderModuleArrayAdjuster + Tileoffs + tileY + 9)
            For tileX = 0 To 7
                palID = ((X1 And ANDtbl(tileX)) <> 0 And 1) Or ((X2 And ANDtbl(tileX)) <> 0 And 1 * 2) Or paloffs
                For j = 0 To jMax
                    For k = 0 To kMax
                        bmix.PalIDSave(((width * j) + k + i), palID)
                    Next k
                Next j
                i += Multiply
            Next tileX
            i += bmp_nexttileYbytes
        Next tileY
    End Sub

    Public Sub DrawSprTile(ByRef bmix As BITMAPINFO, Tileoffs As Double, x As Integer, y As Integer, FlipY As Integer, FlipX As Integer, tilepal As Integer)
        UpdateSprTile(bmix, bmix, Tileoffs, tilepal, x, y, FlipY, FlipX, False)
    End Sub

    Public Sub ClearSprTile(ByRef bmix As BITMAPINFO, Tileoffs As Double, x As Integer, y As Integer, FlipY As Integer, FlipX As Integer, ByRef SrcBMI As BITMAPINFO)
        UpdateSprTile(bmix, SrcBMI, Tileoffs, 0, x, y, FlipY, FlipX, True)
    End Sub

    'Revised 05-14-11 to keep sprites from being wrapped to the other side of the bitmap,
    'and joined the Draw and Clear routines together.
    Public Sub UpdateSprTile(ByRef bmix As BITMAPINFO, ByRef SrcBMI As BITMAPINFO, ByVal Tileoffs As Double, ByRef tilepal As Integer, ByVal x As Integer, ByVal y As Integer, ByRef FlipY As Integer, ByRef FlipX As Integer, ByRef clear As Boolean)
        'Ensure Position is within boundaries
        If Tileoffs < 0 Or Tileoffs > (UBound(romdat) - &HFS) Then Exit Sub

        Dim width, height As Integer
        Dim tileX, tileY As Integer
        Dim X1, X2 As Integer
        Dim i As Integer
        Dim paloffs As Integer
        Dim bmp_nexttileYbytes As Integer
        Dim last_x, start_x, bitmapSize As Integer
        Dim palID As Integer

        'Values will be tested to be within ranges
        If (x + 7) < 0 Then Exit Sub
        If (y + 7) < 0 Then Exit Sub
        width = bmix.Header.biWidth
        height = -bmix.Header.biHeight
        If (x >= width) Then Exit Sub
        If (y >= height) Then Exit Sub

        bitmapSize = bmix.Header.biSizeImage
        paloffs = (tilepal * 4)
        bmp_nexttileYbytes = (width - 8)
        i = (y * width) + x

        If (x < 0) Then
            start_x = -x
            i += start_x
            bmp_nexttileYbytes += start_x
        Else
            start_x = 0
        End If

        If (x + 7) >= width Then
            last_x = 7 - ((x + 7) - (width - 1))
            bmp_nexttileYbytes += CShort(last_x Xor 7)
        Else
            last_x = 7
        End If

        For tileY = 0 To 7
            X1 = romdat(RenderModuleArrayAdjuster + Tileoffs + System.Math.Abs((FlipY * 7) - tileY) + 1)
            X2 = romdat(RenderModuleArrayAdjuster + Tileoffs + System.Math.Abs((FlipY * 7) - tileY) + 9)
            For tileX = start_x To last_x
                palID = ((X1 And ANDtbl(System.Math.Abs((FlipX * 7) - tileX))) <> 0 And 1) Or ((X2 And ANDtbl(System.Math.Abs((FlipX * 7) - tileX))) <> 0 And 1 * 2) Or paloffs
                If (palID And 3) Then
                    If i >= bitmapSize Then Exit Sub
                    If i > -1 Then
                        If clear = False Then
                            bmix.PalIDSave(i, palID)
                        Else
                            bmix.PalIDSave(i, SrcBMI.bytesPal_ByPixelID(i))
                        End If
                    End If
                End If
                i += 1
            Next tileX
            i += bmp_nexttileYbytes
        Next tileY
    End Sub
#End Region

#Region "CSA_Only"
    Public Sub RAW_ZeroBuffer(ByRef bmbu As Bmbuffer)
        Array.Clear(bmbu.data, 0, bmbu.data.Length)
    End Sub

    ' For some elements, using ClientRectangle size (since some picture box have Borders and such) is necessary else
    '   image would be drawn too big for PictureBoxes
    '   This way, for such elements, Borders can be kept.
    Public Sub PB_Init_WithClientRectangle(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
        Dim WidthOf, HeightOf As Integer

        If TilePB.Image Is Nothing Then TilePB.Image = New Bitmap(TilePB.Width, TilePB.Height)
        If bmix Is Nothing Then bmix = New BITMAPINFO()

        WidthOf = TilePB.ClientRectangle.Width
        HeightOf = TilePB.ClientRectangle.Height
        With bmix.Header
            .biSize = 40
            .biWidth = WidthOf
            .biHeight = -HeightOf
            .biPlanes = 1
            .biBitCount = 8
            .biSizeImage = WidthOf * HeightOf
            .biClrUsed = 256
        End With
        bmix.RedimPixelBytes(bmix.Header.biSizeImage)
    End Sub

    Public Sub RAW_Init(ByRef bmbu As Bmbuffer, ByRef h As Integer, ByRef w As Integer)
        bmbu.SX = h
        bmbu.SY = w
        ReDim bmbu.data((h * w) - 1)
    End Sub

    Public Sub RAW_LineH(ByRef bmbu As Bmbuffer, ByRef x1 As Integer, ByRef x2 As Integer, ByRef y As Integer, ByRef col As Integer)
        C_LineH(bmbu.SX, bmbu.data, (bmbu.SX * bmbu.SY), x1, x2, y, col)
    End Sub

    Public Sub RAW_LineV(ByRef bmbu As Bmbuffer, ByRef x As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer, ByRef col As Integer)
        C_LineV(bmbu.SX, bmbu.data, (bmbu.SX * bmbu.SY), x, Y1, Y2, col)
    End Sub

    Private Sub C_LineH(ByRef width As Integer, ByRef buffer() As Byte, ByRef bound As Integer, ByRef x1 As Integer, ByRef x2 As Integer, ByRef y As Integer, ByRef col As Integer)
        Dim a, rowbytebase As Integer
        rowbytebase = (y * width)
        For a = x1 To x2
            If ((rowbytebase + a) < bound) And ((rowbytebase + a) >= 0) Then
                buffer(rowbytebase + a) = col
            End If
        Next a
    End Sub

    Private Sub C_LineV(ByRef width As Integer, ByRef buffer() As Byte, ByRef bound As Integer, ByRef x As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer, ByRef col As Integer)
        Dim a As Integer
        For a = Y1 To Y2
            If (((a * width) + x) < bound) And (((a * width) + x) >= 0) Then
                buffer((a * width) + x) = col
            End If
        Next a
    End Sub

    Public Function Rd(ByRef addr As Integer, romdatParam() As Byte) As Byte
        Rd = 0

        If (addr <= UBound(romdatParam)) Then
            Rd = romdatParam(addr)
        End If
    End Function

    Public Sub RAW_DrawSprTile(ByRef bmbu As Bmbuffer, ByRef y As Integer, ByRef x As Integer, ByRef Tile As Integer, ByRef Attr As Integer, ByRef palbase As Integer, PatternMapParam As Integer(), romdatParam As Byte(), readFromROM As Boolean)

        Dim b0, pixY, pixX, color, b1 As Integer
        Dim paloffs, PT_Ptr As Integer
        Dim rawbm_ptr, rawbm_nextYoffs As Integer
        Dim FlipX_XOR, FlipY_XOR As Integer

        paloffs = (CShort(Attr And 3) * 4) + palbase
        rawbm_nextYoffs = (bmbu.SX - 8)
        rawbm_ptr = (CShort((y + &H80S) And &HFFS) * bmbu.SX) + CShort((x + &H80S) And &HFFS)
        PT_Ptr = Tile * &H10S
        If (Attr And &H80S) Then
            FlipY_XOR = 7
        Else
            FlipY_XOR = 0
        End If
        If (Attr And &H40S) Then
            FlipX_XOR = 7
        Else
            FlipX_XOR = 0
        End If

        For pixY = 0 To 7
            If readFromROM Then
                b0 = Rd(PatternMapParam(PT_Ptr + 0 + CShort(pixY Xor FlipY_XOR)), romdatParam)
                b1 = Rd(PatternMapParam(PT_Ptr + 8 + CShort(pixY Xor FlipY_XOR)), romdatParam)
            Else
                b0 = PatternMapParam(PT_Ptr + 0 + CShort(pixY Xor FlipY_XOR))
                b1 = PatternMapParam(PT_Ptr + 8 + CShort(pixY Xor FlipY_XOR))
            End If
            For pixX = 0 To 7
                color = ((b0 And ANDtbl(pixX Xor FlipX_XOR)) <> 0 And 1) Or ((b1 And ANDtbl(pixX Xor FlipX_XOR)) <> 0 And 1 * 2) Or paloffs
                If (rawbm_ptr >= (bmbu.SX * bmbu.SY)) Then Exit Sub
                If (color And 3) Then
                    bmbu.data(rawbm_ptr) = color
                End If
                rawbm_ptr += 1
            Next pixX
            rawbm_ptr += rawbm_nextYoffs
        Next pixY
    End Sub

    Public Sub Blit1(ByRef rawbm1 As Bmbuffer, ByRef DstPB As PictureBox, ByRef bmip As BITMAPINFO, ByRef zoom As Integer, ByRef baseX As Integer, ByRef baseY As Integer)
        Dim tmpbuf As New Bmbuffer With {
            .SX = 0,
            .SY = 0,
            .data = New Byte() {}
        }
        RAW_Init(tmpbuf, rawbm1.SY, rawbm1.SX)
        RAW_ZeroBuffer(tmpbuf)
        Blit2(rawbm1, tmpbuf, DstPB, bmip, zoom, baseX, baseY)
    End Sub

    'Blit two raw bitmaps together onto a BITMAPINFO bitmap.
    '0 is mask color.
    'Zoom, offset X and Y are definable.
    '(the two bitmaps are assumed the same width.)
    Public Sub Blit2(ByRef rawbm1 As Bmbuffer, ByRef rawbm2 As Bmbuffer, ByRef DstPB As PictureBox, ByRef bmip As BITMAPINFO, ByRef zoom As Integer, ByRef baseX As Integer, ByRef baseY As Integer)
        Dim color As Integer
        Dim pbheight, pbwidth As Integer
        Dim bmibm_nextptr, bmibm_ptr, bmibm_endptr As Integer
        Dim bmirow_bsz2, bmirow_bsz0, bmirow_bsz1, bmirow_bsz3 As Integer
        Dim bmirow_bsz12, bmirow_bsz10, bmirow_bsz11, bmirow_bsz13 As Integer
        Dim bmirow_bsz22, bmirow_bsz20, bmirow_bsz21, bmirow_bsz23 As Integer
        Dim rawbm_nextptr, rawbm_ptr, rawbm_endptr As Integer
        Dim fillX As Integer

        pbheight = DstPB.ClientRectangle.Height
        pbwidth = DstPB.ClientRectangle.Width

        bmibm_ptr = 0
        bmibm_endptr = (pbwidth * pbheight)
        rawbm_endptr = (rawbm1.SX * rawbm1.SY)

        If (baseY < 0) Then
            rawbm_nextptr = 0
        Else
            rawbm_nextptr = (baseY * rawbm1.SX)
        End If

        Select Case zoom
            Case 1

                If (baseY < 0) Then
                    bmibm_nextptr = (-baseY * pbwidth)
                    While Not (bmibm_ptr = bmibm_nextptr)
                        bmip.bytesPal_ByPixelID(bmibm_ptr) = 0
                        bmibm_ptr += 1
                    End While
                End If

                Do

                    bmibm_nextptr = bmibm_ptr + pbwidth

                    If (baseX < 0) Then
                        rawbm_ptr = rawbm_nextptr
                        fillX = baseX
                        While (fillX < 0)
                            bmip.bytesPal_ByPixelID(bmibm_ptr) = 0
                            bmibm_ptr += 1
                            fillX += 1
                        End While
                    Else
                        rawbm_ptr = rawbm_nextptr + baseX
                    End If

                    rawbm_nextptr += rawbm1.SX

                    'While Not (bmibm_ptr = bmibm_nextptr)
                    While (rawbm_ptr <> rawbm_nextptr)
                        'If (rawbm_ptr = rawbm_nextptr) Then
                        '    rawbm_ptr = rawbm_ptr - rawbm1.SX
                        'End If

                        color = rawbm2.data(rawbm_ptr)
                        If Not (color) Then '(if =mask color)
                            If (rawbm1.data(rawbm_ptr)) Then
                                color = rawbm1.data(rawbm_ptr)
                            End If
                        End If

                        bmip.bytesPal_ByPixelID(bmibm_ptr) = color

                        bmibm_ptr += 1

                        rawbm_ptr += 1
                    End While

                    While (bmibm_ptr <> bmibm_nextptr)
                        bmip.bytesPal_ByPixelID(bmibm_ptr) = 0
                        bmibm_ptr += 1
                    End While

                Loop Until (rawbm_ptr >= rawbm_endptr)

                While (bmibm_ptr < bmibm_endptr)
                    bmip.bytesPal_ByPixelID(bmibm_ptr) = 0
                    bmibm_ptr += 1
                End While

                    'Loop Until (bmibm_ptr >= bmibm_endptr)

            Case 2

                bmirow_bsz0 = pbwidth
                bmirow_bsz1 = pbwidth + 1

                Do

                    bmibm_nextptr = bmibm_ptr + pbwidth

                    rawbm_ptr = rawbm_nextptr + baseX

                    rawbm_nextptr += rawbm1.SX

                    While (bmibm_ptr < bmibm_nextptr)
                        'While Not (rawbm_ptr = rawbm_nextptr)
                        If (rawbm_ptr = rawbm_nextptr) Then
                            rawbm_ptr -= rawbm1.SX
                        End If

                        color = rawbm2.data(rawbm_ptr)
                        If Not (color) Then '(if =mask color)
                            If (rawbm1.data(rawbm_ptr)) Then
                                color = rawbm1.data(rawbm_ptr)
                            End If
                        End If

                        bmip.bytesPal_ByPixelID(bmibm_ptr) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 1) = color
                        If bmibm_ptr + bmirow_bsz1 < bmip.bytesPal_ByPixelID.Length Then
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz0) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz1) = color
                        End If

                        bmibm_ptr += 2

                        rawbm_ptr += 1
                    End While
                    bmibm_ptr += pbwidth

                    'Loop Until (rawbm_ptr >= rawbm_endptr)

                Loop Until (bmibm_ptr >= bmibm_endptr)

            Case 3

                bmirow_bsz0 = pbwidth + 0
                bmirow_bsz1 = pbwidth + 1
                bmirow_bsz2 = pbwidth + 2
                bmirow_bsz10 = (pbwidth * 2)
                bmirow_bsz11 = bmirow_bsz10 + 1
                bmirow_bsz12 = bmirow_bsz10 + 2

                Do

                    bmibm_nextptr = bmibm_ptr + pbwidth

                    rawbm_ptr = rawbm_nextptr + baseX

                    rawbm_nextptr += rawbm1.SX

                    While (bmibm_ptr < bmibm_nextptr)
                        'While Not (rawbm_ptr = rawbm_nextptr)
                        If (rawbm_ptr = rawbm_nextptr) Then
                            rawbm_ptr -= rawbm1.SX
                        End If

                        color = rawbm2.data(rawbm_ptr)
                        If Not (color) Then '(if =mask color)
                            If (rawbm1.data(rawbm_ptr)) Then
                                color = rawbm1.data(rawbm_ptr)
                            End If
                        End If

                        bmip.bytesPal_ByPixelID(bmibm_ptr) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 1) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 2) = color
                        If bmibm_ptr + bmirow_bsz12 < bmip.bytesPal_ByPixelID.Length Then
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz0) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz1) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz2) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz10) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz11) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz12) = color
                        End If

                        bmibm_ptr += 3

                        rawbm_ptr += 1
                    End While
                    bmibm_ptr += bmirow_bsz10

                    'Loop Until (rawbm_ptr >= rawbm_endptr)

                Loop Until (bmibm_ptr >= bmibm_endptr)


            Case 4

                bmirow_bsz0 = pbwidth
                bmirow_bsz1 = pbwidth + 1
                bmirow_bsz2 = pbwidth + 2
                bmirow_bsz3 = pbwidth + 3
                bmirow_bsz10 = (pbwidth * 2)
                bmirow_bsz11 = bmirow_bsz10 + 1
                bmirow_bsz12 = bmirow_bsz10 + 2
                bmirow_bsz13 = bmirow_bsz10 + 3
                bmirow_bsz20 = (pbwidth * 3)
                bmirow_bsz21 = bmirow_bsz20 + 1
                bmirow_bsz22 = bmirow_bsz20 + 2
                bmirow_bsz23 = bmirow_bsz20 + 3

                Do

                    bmibm_nextptr = bmibm_ptr + pbwidth

                    rawbm_ptr = rawbm_nextptr + baseX

                    rawbm_nextptr += rawbm1.SX

                    While (bmibm_ptr < bmibm_nextptr)
                        'While Not (rawbm_ptr = rawbm_nextptr)
                        If (rawbm_ptr = rawbm_nextptr) Then
                            rawbm_ptr -= rawbm1.SX
                        End If

                        color = rawbm2.data(rawbm_ptr)
                        If Not (color) Then '(if =mask color)
                            If (rawbm1.data(rawbm_ptr)) Then
                                color = rawbm1.data(rawbm_ptr)
                            End If
                        End If

                        bmip.bytesPal_ByPixelID(bmibm_ptr) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 1) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 2) = color
                        bmip.bytesPal_ByPixelID(bmibm_ptr + 3) = color
                        If bmibm_ptr + bmirow_bsz23 < bmip.bytesPal_ByPixelID.Length Then
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz0) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz1) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz2) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz3) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz10) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz11) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz12) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz13) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz20) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz21) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz22) = color
                            bmip.bytesPal_ByPixelID(bmibm_ptr + bmirow_bsz23) = color
                        End If

                        bmibm_ptr += 4

                        rawbm_ptr += 1
                    End While
                    bmibm_ptr += bmirow_bsz20

                    'Loop Until (rawbm_ptr >= rawbm_endptr)

                Loop Until (bmibm_ptr >= bmibm_endptr)


        End Select

    End Sub
End Module
#End Region

#Region "Commented"
#Region "Old_Stuff"
'Was like this at one point
'Public Sub RenderPicAlwaysIfItWasChangedSinceLastupdate(ByRef TilePB As PictureBox, ByRef bmix As BITMAPINFO)
'    ' To save time, ensure picture was edited or needed editing before rendering it
'    If bmix.bytesRGB_UpdatedSinceLastRender = False And bmix.palette_UpdatedSinceLastBytesRGB_Update = False Then Exit Sub
'
'    ' If palette was Updated, need to reupdate bytesRGB (if was not updated already)
'    If bmix.bytesRGB_UpdatedSinceLastRender = False And bmix.palette_UpdatedSinceLastBytesRGB_Update = True Then
'        bmix.UpdateByteRGBFromPixelBytes()
'    End If
'
'    bmix.bytesRGB_UpdatedSinceLastRender = False
'    bmix.palette_UpdatedSinceLastBytesRGB_Update = False
'
'    ' Create a compatible Bitmap object based on bmix dimensions (will need to be scaled for actual PictureBox)
'    Dim bmpSrc As New Bitmap(bmix.Header.biWidth, -bmix.Header.biHeight, Imaging.PixelFormat.Format32bppArgb)
'    Dim bmpDest As New Bitmap(TilePB.Width, TilePB.Height, Imaging.PixelFormat.Format32bppArgb)
'    Dim bmpData As BitmapData = bmpSrc.LockBits(New Rectangle(0, 0, bmpSrc.Width, bmpSrc.Height), ImageLockMode.WriteOnly, bmpSrc.PixelFormat)
'
'    ' Copy all bytes to bitmap
'    Marshal.Copy(bmix.bytesRGB_ByPixelID, 0, bmpData.Scan0, bmix.bytesRGB_ByPixelID.Length)
'
'    ' Unlock
'    bmpSrc.UnlockBits(bmpData)
'
'    If (bmpSrc.Width = bmpDest.Width And bmpSrc.Height = bmpDest.Height) Then
'        ' Assign the bitmap to the PictureBox's Image property
'        TilePB.Image = bmpSrc
'    Else
'        ' Image will need to be scaled
'        ScaleBmp(bmpSrc, bmpDest)
'        ' Assign the bitmap to the PictureBox's Image property
'        TilePB.Image = bmpDest
'    End If
'
'    TilePB.Refresh()
'End Sub

'Public Function RenderPic(ByRef TilePB As ExtendedPictureBox, ByRef bmix As BITMAPINFO) As Integer
'    Dim pbmi As IntPtr
'    If RefreshLock = True Then Exit Function
'    pbmi = VarPtr(bmix)

'    ' was RenderPic = SetDIBits(TilePB.hdc, TilePB.Image.Handle, 0,
'    PixelsToTwipsY(TilePB.ClientRectangle.Height), bmix.bits(0), pbmi, 0)
'    Dim graphics As Graphics = TilePB.CreateGraphics()
'    Dim TilePBhdc As IntPtr = graphics.GetHdc()
'    Dim bitmap As Bitmap = CType(TilePB.Image, Bitmap)
'    Dim TilePBImageHandle As IntPtr = bitmap.GetHbitmap()

'    RenderPic = SetDIBits(TilePBhdc, TilePBImageHandle, 0, ScaleHeightFromVB6ScaleMode(TilePB), bmix.bits(0), pbmi, 0)
'    TilePB.Refresh()
'    graphics.ReleaseHdc(TilePBhdc)
'End Function
'
'
'No RefreshLock check, used for render with temporary allocated bitmaps (Graphics Load Editor)
'Public Function RenderPicAlwaysIfItWasChangedSinceLastupdate(ByRef TilePB As ExtendedPictureBox, ByRef bmix As BITMAPINFO) As Integer
'    Dim pbmi As Integer
'    pbmi = VarPtr(bmix)
'    ' was RenderPicAlwaysIfItWasChangedSinceLastupdate = SetDIBits(TilePB.hdc, TilePB.Image.Handle, 0, VB6.PixelsToTwipsY(TilePB.ClientRectangle.Height), bmix.bits(0), pbmi, 0)
'    Dim graphics As Graphics = TilePB.CreateGraphics()
'    Dim TilePBhdc As IntPtr = graphics.GetHdc()
'    Dim bitmap As Bitmap = CType(TilePB.Image, Bitmap)
'    Dim TilePBImageHandle As IntPtr = bitmap.GetHbitmap()
'    'will need to replace it
'    'RenderPicAlwaysIfItWasChangedSinceLastupdate = SetDIBits(TilePBhdc, TilePBImageHandle, 0, ScaleHeightFromVB6ScaleMode(TilePB), bmix.bits(0), pbmi, 0)
'    TilePB.Refresh()
'    graphics.ReleaseHdc(TilePBhdc)
'End Function

'Calls DrawTileX sub based on dimensioning. When "Multiply" is a known value, DrawTile1 or DrawTile2 should be called without calling this.
'Public Sub DrawTile(ByRef bmix As BITMAPINFO, ByVal Tileoffs As Single, ByRef tilepal As Integer, ByVal x As Integer, ByVal y As Integer, ByVal Multiply As Integer)
'    If Multiply = 1 Then
'        DrawTile1(bmix, Tileoffs, tilepal, x, y, 1)
'    Else
'        DrawTile2(bmix, Tileoffs, tilepal, x, y)
'    End If
'End Sub

'Public Sub DrawTile1(ByRef bmix As BITMAPINFO, ByVal Tileoffs As Single, ByRef tilepal As Integer, ByVal x As Integer, ByVal y As Integer)
'    If Tileoffs < 0 Or Tileoffs > (UBound(romdat) - &HFS) Then Exit Sub

'    Dim width, height As Integer
'    Dim tileX, tileY As Integer
'    Dim X1, TileColour, X2 As Integer
'    Dim i As Integer
'    Dim paloffs As Integer
'    Dim bmp_nexttileYbytes As Integer

'    width = bmix.Header.biWidth
'    height = -bmix.Header.biHeight
'    paloffs = (tilepal * 4)
'    bmp_nexttileYbytes = (width - 8)

'    i = (y * width) + x
'    For tileY = 0 To 7
'        X1 = romdat(arrayAdjuster + Tileoffs + tileY + 1)
'        X2 = romdat(arrayAdjuster + Tileoffs + tileY + 9)
'        For tileX = 0 To 7
'            TileColour = ((X1 And ANDtbl(tileX)) <> 0 And 1) Or ((X2 And ANDtbl(tileX)) <> 0 And 1 * 2) Or paloffs
'            'If i > (bmix.Header.biSizeImage - 1) Then Exit Sub
'            'If i > -1 Then
'            bmix.bits(i) = TileColour
'            'End If
'            i = i + 1
'        Next tileX
'        i = i + bmp_nexttileYbytes
'    Next tileY
'End Sub

#Region "CSA_Render from CSA"
'Option Strict Off
'Option Explicit On
'Module CSA_Render
'	'UPGRADE_NOTE: DefLng A-Z statement was removed. Variables were explicitly declared as type Integer. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="92AFD3E3-440D-4D49-A8BF-580D74A8C9F2"'

'	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
'	'Private Declare Sub ZeroMem Lib "kernel32" Alias "RtlZeroMemory" (ByRef pDest As Any, ByVal Bytes As Integer)
'	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
'	Private Declare Function SetDIBits Lib "gdi32" (ByVal hdc As Integer, ByVal hBitmap As Integer, ByVal nStartScan As Integer, ByVal nNumScans As Integer, ByRef lpBits As Any, ByVal lpBI As Integer, ByVal wUsage As Integer) As Integer

'	Public Structure BITMAPINFOHEADER
'		Dim biSize As Integer
'		Dim biWidth As Integer
'		Dim biHeight As Integer
'		Dim biPlanes As Short
'		Dim biBitCount As Short
'		Dim biCompression As Integer
'		Dim biSizeImage As Integer
'		Dim biXPelsPerMeter As Integer
'		Dim biYPelsPerMeter As Integer
'		Dim biClrUsed As Integer
'		Dim biClrImportant As Integer
'	End Structure
'	Public Structure BITMAPINFO
'		Dim Header As BITMAPINFOHEADER
'		<VBFixedArray(255)> Dim pal() As Integer
'		Dim bits() As Byte

'		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
'		Public Sub Initialize()
'			ReDim pal(255)
'		End Sub
'	End Structure

'	Public Structure Bmbuffer
'		Dim SX As Integer
'		Dim SY As Integer
'		Dim data() As Byte
'	End Structure





'	Public Function RenderPic(ByRef BMPB As System.Windows.Forms.PictureBox, ByRef bmix As BITMAPINFO) As Integer
'		bmix = bmix
'       RenderPic = SetDIBits(BMPB.hdc, BMPB.Image.Handle, 0, VB6.PixelsToTwipsY(BMPB.ClientRectangle.Height), bmix.bits(0), VarPtr(bmix), 0)
'		BMPB.Refresh()
'	End Function

'	Public Sub PB_Init(ByRef BMPB As System.Windows.Forms.PictureBox, ByRef bmix As BITMAPINFO)
'		Dim WidthOf, HeightOf As Integer
'		WidthOf = VB6.PixelsToTwipsX(BMPB.ClientRectangle.Width)
'		HeightOf = VB6.PixelsToTwipsY(BMPB.ClientRectangle.Height)
'		With bmix.Header
'			.biSize = 40
'			.biWidth = WidthOf
'			.biHeight = -HeightOf
'			.biPlanes = 1
'			.biBitCount = 8
'			.biSizeImage = 2 * (WidthOf - 1) * (HeightOf - 1)
'			.biClrUsed = 256
'		End With
'		ReDim bmix.bits(bmix.Header.biSizeImage - 1)
'	End Sub

'	Public Sub PB_ReSizeInit(ByRef BMPB As System.Windows.Forms.PictureBox, ByRef bmix As BITMAPINFO)
'		Dim WidthOf, HeightOf As Integer
'		WidthOf = VB6.PixelsToTwipsX(BMPB.ClientRectangle.Width)
'		HeightOf = VB6.PixelsToTwipsY(BMPB.ClientRectangle.Height)
'		With bmix.Header
'			.biWidth = WidthOf
'			.biHeight = -HeightOf
'			.biSizeImage = 2 * (WidthOf - 1) * (HeightOf - 1)
'		End With
'		ReDim bmix.bits(bmix.Header.biSizeImage - 1)
'	End Sub

'	Public Sub Reset_Bits(ByRef bmix As BITMAPINFO)
'		ReDim bmix.bits(0)
'		ReDim bmix.bits(bmix.Header.biSizeImage - 1)
'	End Sub
#End Region
#End Region

#Region "WasAlreadyCommented"
'Draw "X" - SBD Editor
'- Cutom routine im not using anyway -
'Public Sub DrawX(Picbox As PictureBox, ByRef bmix As BITMAPINFO, x, y)
'Dim px As Long, py As Long
'Dim srcColour, Colour As Long
'Dim i As Long, mx As Long, my As Long
'Dim width, height
'width = Picbox.width
'height = Picbox.height
'For py = 0 To 15
'For px = 0 To 15
'    Colour = rdata(dspa(d_sbded_cross) + (py * 16) + px) + &H20
'    For my = 0 To 1
'    For mx = 0 To 1
'    i = ((y * width) + (py * width) * 2 + my * width) + x + px * 2 + mx
'    If i > (bmix.Header.biSizeImage - 1) Then Exit Sub
'    'If (((Y * width) + (tileY * width) * Multiply + my * width) + X + tileX * Multiply + mx) > -1 Then
'    bmix.bits(i) = Colour
'    'End If
'    Next mx
'    Next my
'Next px
'Next py
'End Sub

'Prepare Parameters of image to draw



'Public Sub DrawSprTile_Br(TilePB As PictureBox, bmix As BITMAPINFO, src_bmix As BITMAPINFO, Tileoffs As Long, Colors(), ByVal x As Long, ByVal y As Long, ByVal Multiply As Long, FlipY, FlipX, BrY1, BrX1, BrY2, BrX2)
'Dim width, height
'width = TilePB.width
'height = TilePB.height
''  If bInit = False Then Exit Function
'  Dim tileX As Long, tileY As Long
'  Dim TileColour As Long, X1 As Long, X2 As Long
'  Dim i As Long, mx As Long, my As Long
'
'  For tileY = 0 To 7
'  X1 = Asc(Mid$(romdat, Tileoffs + (Abs((FlipY * 7) - tileY) * 2) + 1, 1))
'  X2 = Asc(Mid$(romdat, Tileoffs + (Abs((FlipY * 7) - tileY) * 2) + 2, 1))
''byteA = Asc(mid$(romdat, Source + (Abs((FlipY * 7) - pixY) * 2) + 1, 1))
''byteB = Asc(mid$(romdat, Source + (Abs((FlipY * 7) - pixY) * 2) + 2, 1))
'
'  For tileX = 0 To 7
'    TileColour = _
''      ((X1 And (2 ^ (7 - Abs((FlipX * 7) - tileX)))) > 0 And 1) + _
''      ((X2 And (2 ^ (7 - Abs((FlipX * 7) - tileX)))) > 0 And 1 * 2)
' '     ((X1 And (2 ^ (7 - tileX))) > 0 And 1) + _
'' '     ((X2 And (2 ^ (7 - tileX))) > 0 And 1 * 2)
'    If TileColour Then
'    For my = 0 To Multiply - 1
'    For mx = 0 To Multiply - 1
'    i = ((y * width) + (tileY * width) * Multiply + my * width) + x + tileX * Multiply + mx
'    If i > (bmix.Header.biSizeImage - 1) Then Exit Sub
''      If i > width * height * 4 Then Exit Function
'    If (x + (tileX * Multiply) + mx) >= BrX1 And (x + (tileX * Multiply) + mx) <= BrX2 And (y + (tileY * Multiply) + my) >= BrY1 And (y + (tileY * Multiply) + my) <= BrY2 Then
' '   If i > width * height * 4 Then Exit Sub
'    If i > -1 Then
''    If (((y * width) + (tileY * width) * Multiply + my * width) + x + tileX * Multiply + mx) < width * height Then
'        bmix.bits(i) = src_bmix.bits(i)
''    End If
'    End If
'    End If
'    Next mx
'    Next my
'    End If
'  Next tileX
'  Next tileY
'End Sub
#End Region

#Region "WasUnused"
'Public Sub Reset_Bits(ByRef TilePB As System.Windows.Forms.PictureBox, ByRef bmix As BITMAPINFO)
'    ReDim bmix.bits(0)
'    ReDim bmix.bits(bmix.Header.biSizeImage - 1)
'End Sub
#End Region
#End Region