namespace Starlib.Bindings
{
    public delegate FT_Error FTC_Face_Requester(nint faceId, nint library, nint requestData, out nint aface);
}