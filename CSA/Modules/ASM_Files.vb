Option Explicit On

Module ASM_Files
    Structure AnimationData
        Dim _name As String
        Dim _qtySprites As String
        Dim _delay As String
        Dim _sprites As String()
    End Structure

    Structure SpriteData
        Dim _name As String
        Dim _qtyTiles As String
        Dim _crdName As String
        Dim _tilesID As String()
        Dim _tilesAttributes As String()
    End Structure

    Structure CoordinateData
        Dim _name As String
        Dim _Y As String()
        Dim _X As String()
    End Structure
End Module