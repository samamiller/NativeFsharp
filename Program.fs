open Windows.Win32
open System
open System.Diagnostics

let mutable bitmapInfo = Graphics.Gdi.BITMAPINFO()
bitmapInfo.bmiHeader.biPlanes <- 1us
bitmapInfo.bmiHeader.biBitCount <- 32us
bitmapInfo.bmiHeader.biSize <- uint sizeof<Graphics.Gdi.BITMAPINFOHEADER>
let mutable bitmap = NativeInterop.NativePtr.stackalloc<byte>(100)
let mutable bitmapMemory = bitmap |> NativeInterop.NativePtr.toVoidPtr
let mutable bitmapHandle = Graphics.Gdi.HBITMAP()
let mutable bitmapDeviceContext = Graphics.Gdi.HDC()

let win32ResizeDIBSection width height =
    bitmapInfo.bmiHeader.biWidth <- width
    bitmapInfo.bmiHeader.biHeight <- height
    bitmapHandle <- PInvoke.CreateDIBSection(bitmapDeviceContext, &&bitmapInfo, Graphics.Gdi.DIB_USAGE.DIB_RGB_COLORS, &&bitmapMemory, Foundation.HANDLE 0n, 0u)

[<EntryPoint>]
let main _ =
    
    0
