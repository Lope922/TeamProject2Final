Imports FlickrNet
Imports System.Xml

Public Class flickRpart
    '' use nuget to install this flickr package  Install - Package FlickrNet

    '' use this key to request a token using key, but not secret  
    Dim apiKey As String = "4f60a04f101ef604ead9be84856d9519"

    Dim f As Flickr = New Flickr(apiKey)

    '' get an imagelist with the following properties

    Public Sub GetImages(city As String, picOptions As Integer, Tags As String, ContentType As Integer, HasGeo As Integer)

        'Set of code to get the picture from the Flickr API.
        Dim searchOptions As PhotoSearchOptions = New PhotoSearchOptions()

        '' use the tags of the city name and the landmarks 
        searchOptions.Tags = city & " landmark"

        searchOptions.ContentType = ContentTypeSearch.PhotosOnly

        searchOptions.HasGeo = 1

        searchOptions.Page = 1

        searchOptions.PerPage = 3

        '' these only return photos that have geo tags, but does not limit the range for the geotags


        '' store the response photos as a photo collection. 
        Dim responsePhotos As PhotoCollection = f.PhotosSearch(searchOptions)

        Dim picInfo As String = ""
        Dim picURL As String = ""

        For Each pic As Photo In responsePhotos
            picURL = pic.SmallUrl.ToString

        Next

        '' display that image to an imagebox object
        ' pictureBox.ImageLocation = picURL

        ' MessageBox.Show(picInfo)
    End Sub


    '' no matter the results in order to create a web request for the images i need to generate the following url format 
    '' https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}.jpg

    Public Sub retrievePhotoNodes(flickphotoResponseStream)

        '' first i will need to load the response from the webrequest from photos 
        Dim xmlPhotosResponse As XmlDocument = flickphotoResponseStream.selecSingleNode(farmNode)

        Dim farmNode As XmlNode = 

        '' add the nodes needed for the photo request. 

    End Sub



End Class

'' to do set the predefined classes to search with 

'' then create a photos collection from the restponse and add them to the photo list 

'' then for each photo in the photos collection add that photo to the picture box 



