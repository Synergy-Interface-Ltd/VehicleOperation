Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Public Class RandomImage
    'Default Constructor 
    Public Sub New()
    End Sub
    'property
    Public ReadOnly Property Text() As String
        Get
            Return Me.m_text
        End Get
    End Property
    Public ReadOnly Property Image() As Bitmap
        Get
            Return Me.m_image
        End Get
    End Property
    Public ReadOnly Property Width() As Integer
        Get
            Return Me.m_width
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return Me.m_height
        End Get
    End Property
    'Private variable
    Private m_text As String
    Private m_width As Integer
    Private m_height As Integer
    Private m_image As Bitmap
    Private random As New Random()
    'Methods declaration
    Public Sub New(ByVal s As String, ByVal width As Integer, ByVal height As Integer)
        Me.m_text = s
        Me.SetDimensions(width, height)
        Me.GenerateImage()
    End Sub
    Public Sub Dispose()
        GC.SuppressFinalize(Me)
        Me.Dispose(True)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Me.m_image.Dispose()
        End If
    End Sub
    Private Sub SetDimensions(ByVal width As Integer, ByVal height As Integer)
        If width <= 0 Then
            Throw New ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.")
        End If
        If height <= 0 Then
            Throw New ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.")
        End If
        Me.m_width = width
        Me.m_height = height
    End Sub
    Private Sub GenerateImage()
        Dim bitmap As New Bitmap(Me.m_width, Me.m_height, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As New Rectangle(0, 0, Me.m_width, Me.m_height)
        Dim hatchBrush As New HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White)
        g.FillRectangle(hatchBrush, rect)
        Dim size As SizeF
        Dim fontSize As Single = rect.Height + 1
        Dim font As Font

        Do
            fontSize -= 1
            font = New Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold)
            size = g.MeasureString(Me.m_text, font)
        Loop While size.Width > rect.Width
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        Dim path As New GraphicsPath()
        'path.AddString(this.text, font.FontFamily, (int) font.Style, 
        '    font.Size, rect, format);
        path.AddString(Me.m_text, font.FontFamily, CInt(font.Style), 45, rect, format)
        Dim v As Single = 4.0F
        Dim points As PointF() = {New PointF(Me.random.[Next](rect.Width) / v, Me.random.[Next](rect.Height) / v), New PointF(rect.Width - Me.random.[Next](rect.Width) / v, Me.random.[Next](rect.Height) / v), New PointF(Me.random.[Next](rect.Width) / v, rect.Height - Me.random.[Next](rect.Height) / v), New PointF(rect.Width - Me.random.[Next](rect.Width) / v, rect.Height - Me.random.[Next](rect.Height) / v)}
        Dim matrix As New Matrix()
        matrix.Translate(0.0F, 0.0F)
        path.Warp(points, rect, matrix, WarpMode.Perspective, 0.0F)
        hatchBrush = New HatchBrush(HatchStyle.Percent10, Color.Black, Color.SkyBlue)
        g.FillPath(hatchBrush, path)
        Dim m As Integer = Math.Max(rect.Width, rect.Height)
        For i As Integer = 0 To CInt(Math.Truncate(rect.Width * rect.Height / 30.0F)) - 1
            Dim x As Integer = Me.random.[Next](rect.Width)
            Dim y As Integer = Me.random.[Next](rect.Height)
            Dim w As Integer = Me.random.[Next](m \ 50)
            Dim h As Integer = Me.random.[Next](m \ 50)
            g.FillEllipse(hatchBrush, x, y, w, h)
        Next
        font.Dispose()
        hatchBrush.Dispose()
        g.Dispose()
        Me.m_image = bitmap
    End Sub
End Class
