Imports FlickrNet

Public Class flickRpart
    '' use nuget to install this flickr package  Install - Package FlickrNet

    '' use this key to request a token to generate request. 
    Dim apiKey As String = "4f60a04f101ef604ead9be84856d9519"

    Dim f As Flickr = New Flickr(apiKey)


    Public Sub GetImage(city As String, pictureBox As PictureBox, picOptions As Integer)

        'Set of code to get the picture from the Flickr API.
        Dim searchOptions As PhotoSearchOptions = New PhotoSearchOptions()

        searchOptions.Tags = city & "landmark"

        searchOptions.HasGeo = True

        searchOptions.Page = picOptions

        searchOptions.PerPage = 3
        Dim destinationPhotos As PhotoCollection = f.PhotosSearch(searchOptions)

        Dim picInfo As String = ""
        Dim picURL As String = ""

        For Each pic As Photo In destinationPhotos
            picURL = pic.SmallUrl.ToString

        Next

        '' display that image to an imagebox
        pictureBox.ImageLocation = picURL

        ' MessageBox.Show(picInfo)
    End Sub

End Class


'' set the predefined tags to search flickr with. 



End Class
