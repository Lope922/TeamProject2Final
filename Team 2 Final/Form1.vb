Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports FlickrNet
Imports simpleOauth


Public Class Form1

    'Map
    Private Sub btnGetMap_Click(sender As Object, e As EventArgs) Handles btnGetMap.Click
        'Use string builder to build url for map request
        Dim mapURL As String = mapstringBuilder()
        Dim webRequestMap As WebRequest = WebRequest.Create(mapURL)

        'get response stream
        Dim mapResponseStream As Stream = webRequestMap.GetResponse.GetResponseStream()
        Dim mapImage As Image = Image.FromStream(mapResponseStream)
        'fill image box with the map
        picMap.Image = mapImage

    End Sub

    Private Function mapstringBuilder()
        'this function reads the city and state text and combo boxes, builds the map url and then returns it
        Dim city As String = txtBoxCityName.Text
        Dim State As String = stateComboBox.Text

        Dim finalURL As String = "http://dev.virtualearth.net/REST/V1/Imagery/Map/Road/" & city & "%20" & State & "?mapLayer=TrafficFlow&key=An-81Wbif7kcwdVz7O47yB-qL873cvss4xlu5agBGySz9TGgL62UNqZNmKgIA5EO"
        Return finalURL
    End Function

    'Weather

    ' build a web request for 3 day forecast off of this.
    ' http://api.wunderground.com/api/ede6553743c4d570/forecast/q/MO/St_Louis.xml
    ' a function that returns the vlaue of the txtbox input
    Public Function retrieveTxtboxCity() As String
        Dim cityFromtxtBox As String = txtBoxCityName.Text
        If txtBoxCityName.Text = "" Or txtBoxCityName.Text = Nothing Then
            MessageBox.Show("Please enter a city name ", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Stop
        Else
            Return cityFromtxtBox
        End If
        '' both city and state could return a null reference exception on run time. How can i fix this ?
    End Function

    'retrieves the state from the comob box and handles not selecting errors
    Public Function retrieveState() As String
        Dim state As String = stateComboBox.Text.ToString
        If stateComboBox.Text = Nothing Then
            MessageBox.Show("Select a state from the combo dropdown box", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            Return state
        End If
    End Function

    '' the function that builds the url request from user input
    Public Function url_request_built() As String
        'Dim test_url As String = "http://api.wunderground.com/api/ede6553743c4d570/forecast/q/MO/St_Louis.xml"
        Try
            Dim ThreeDayForecastRequest As String = "http://api.wunderground.com/api/ede6553743c4d570/forecast/q" + "/" + retrieveState() + "/" + retrieveTxtboxCity() + ".xml"
            Return ThreeDayForecastRequest
        Catch problemBuildintUrl As Exception
            MessageBox.Show("Problem generating webrequest. Check that all data has been entered correctly", "Error processing request", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    '' as a background worker i should be able to call diffferent web request. So they should be queued up here.
    Private Sub apiBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles apiBackgroundWorker.DoWork

    End Sub
    Private Sub txtBoxCityName_Click(sender As Object, e As EventArgs) Handles txtBoxCityName.Click
        txtBoxCityName.Clear()
    End Sub


    Private Sub btnGetWeather_Click(sender As Object, e As EventArgs) Handles btnGetWeather.Click
        ' the test url
        ' Try
        'the web request
        Dim webRequestForecast As WebRequest = WebRequest.Create(url_request_built())
        '' comes back as a stream, prepare a variable to handle/process stream
        Dim forecastResponseStream As Stream = webRequestForecast.GetResponse.GetResponseStream()
        Dim xmlWeatherReader As New XmlDocument
        xmlWeatherReader.Load(forecastResponseStream)
        '' from the response stream i need to be able to read.
        Dim xmlDay As XmlNode = xmlWeatherReader.SelectSingleNode("//title")
        '' //title as day of the week
        'trying to access a specific day in the returned list of title elements. The 3rd day is what i want.
        Dim xmlday2 As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[3]/title")
        Dim xmlNodeDay2url_icon As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[3]/icon_url")
        Dim xmlday2Description As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[3]/icon")
        lblday2.Text = xmlday2.InnerText
        lblDescription2.Text = xmlday2Description.InnerText
        Dim xmlday3 As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[5]/title")
        Dim xmlNodeDay3url_icon As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[5]/icon_url")
        Dim xmlday3Description As XmlNode = xmlWeatherReader.SelectSingleNode("//forecastday[5]/icon")
        lblday3.Text = xmlday3.InnerText
        lblDescription3.Text = xmlday3Description.InnerText
        '' //icon for a brief description of the weather
        Dim xmlIconDescription As XmlNode = xmlWeatherReader.SelectSingleNode("//icon")
        '' //icon_url as the icon image to read from the stream
        'MessageBox.Show("day 2 " + xmlday2.InnerXml)
        Dim xmlIconRequestURL As XmlNode = xmlWeatherReader.SelectSingleNode("//icon_url")
        lblday.Text = xmlDay.InnerText
        ''// fctext equals forecast text description
        lblDescription1.Text = xmlIconDescription.InnerText
        ' Catch any exceptions.
        ' Catch problemReadingXML As Exception
        ' MessageBox.Show("There was a problem Reading the xml file. " + vbCrLf + "Check to make sure you are connectedt to the internet ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' End Try
        'testLabel.Text = xmlIconRequestURL.InnerText
        '' now get the image for the forecast and draw it to the picture box
        '' this chunk of code becomes inacessable from previous try catch statements. removed for testing
        Try
            Dim icon_url As String = xmlIconRequestURL.InnerText
            Dim icon2 As String = xmlNodeDay2url_icon.InnerText
            Dim icon3 As String = xmlNodeDay3url_icon.InnerText
            Dim iconWebRequest As WebRequest = WebRequest.Create(icon_url)
            Dim webimageResonse As Stream = iconWebRequest.GetResponse.GetResponseStream()
            Dim weatherDay1Icon As Image = Image.FromStream(webimageResonse)
            forecastImageBox1.Image = weatherDay1Icon
            Dim iconWebRequest2 As WebRequest = WebRequest.Create(icon2)
            Dim webimageResonse2 As Stream = iconWebRequest2.GetResponse.GetResponseStream()
            Dim weatherDayIcon2 As Image = Image.FromStream(webimageResonse2)
            forecastImageBox2.Image = weatherDayIcon2
            Dim iconWebRequest3 As WebRequest = WebRequest.Create(icon3)
            Dim webimageResonse3 As Stream = iconWebRequest3.GetResponse.GetResponseStream()
            Dim weatherDayIcon3 As Image = Image.FromStream(webimageResonse3)
            forecastImageBox3.Image = weatherDayIcon3
            'Dim g As Graphics
            'forcastImageBox = g.DrawImage(Image.FromStream(weatherDay1Icon), New Rectangle(0, 0, forcastImageBox.Width, forcastImageBox.Height))
        Catch ex As WebException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Flickr

    '' FLCIKR API KEY 4f60a04f101ef604ead9be84856d9519
    '' FLICKR API SECRET 4e3fc31dff403d28
    Public Function city() As String
        Dim cityFromTextBox As String
        cityFromTextBox = txtBoxCityName.Text
        If cityFromTextBox.Contains(" ") Then
            cityFromTextBox.Replace(" ", "+")
            Return cityFromTextBox
        End If
    End Function

    Public Function state() As String
        Dim stateFromComboBox As String
        stateFromComboBox = CStr(stateComboBox.SelectedItem())
        Return stateFromComboBox
    End Function

    Public Function callCityAndState() As String
        'city()
        'state()
        MessageBox.Show("city and state " + city() + state())
    End Function


    Private Sub btnGetFlickr_Click(sender As Object, e As EventArgs) Handles btnGetFlickr.Click
        '' call city and state fuctions
        ' callCityAndState()
        '' base api method use
        ' https://api.flickr.com/services/rest/?method=flickr.photos.search
        '' api key required to make request. This is a temp key expires every 24 hours
        '&api_key=348389c8e6dfd154eeccac983fb067b3
        '&tags=St.+Paul%2C+MN&safe_search=1
        '&content_type=1
        '&lat=44.97010040
        '&lon=-93.08209991
        '&radius=10
        '&radius_units=mi
        'only asking for 3 requests per page
        '&per_page=3
        '&page=1
        '' returned in a rest -xml format
        '&format=rest"
        Try
            '' still need to rebuild using the flickr.photo.search method with custom search options similar to ones specified here.
            '' this search request is for St. Louis, MO. this particular method does not need to be authorized. and most parameters are optional.
            Dim cityName As String = txtBoxCityName.Text
            Dim requestedTest As String = "https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=c4471b9774deb717aa6c61f6b88e259a&tags=" & cityName & "&per_page=3&page=2&format=rest"
            '' create the web request using the above url
            Dim flickrRequestPhoto As WebRequest = WebRequest.Create(requestedTest)
            '' store the response stream in the created variable
            Dim testResponseStream As Stream = flickrRequestPhoto.GetResponse.GetResponseStream()
            '' create a xmldocument to format the response
            Dim xmlReader As New XmlDocument
            '' select the single xml-rpc response node
            ' Dim xmlRPCNode As XmlNode
            xmlReader.Load(testResponseStream)
            ' Save the document to a file. White space is
            ' preserved (no white space). = true
            xmlReader.PreserveWhitespace = False '' set to false to preserve the same format as formatted response
            xmlReader.Save("data.xml") '' save the document in the debugger and use response to practice extracting info.
            '' need to obtain xml-rpc siblings at the following values
            ''secret path single node request = //photo/@secret this returns the location. Need to access inner text/xml by calling the innner text method
            Dim url_builder_for_photo_secret1_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo/@secret")
            Dim url_builder_for_photo_secret2_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo[2]/@secret")
            Dim url_builder_for_photo_secret3_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo[3]/@secret")
            'server id'
            Dim url_builder_for_photo_serverID1_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo/@server")
            Dim url_builder_for_photo_serverID2_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo[2]/@server")
            Dim url_builder_for_photo_serverID3_value_from_XML As XmlNode = xmlReader.SelectSingleNode("//photo[3]/@server")
            'id'
            Dim url_builder_for_photo_ID1_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo/@id")
            Dim url_builder_for_photo_ID2_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo[2]/@id")
            Dim url_builder_for_photo_ID3_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo[3]/@id")
            ' Dim xmlRpcElemet As XmlNodeList = xmlReader.SelectNodes("//photos/@farm")
            '' use this to request farm value
            Dim url_builder_for_farm1_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo/@farm")
            Dim url_builder_for_farm2_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo[2]/@farm")
            Dim url_builder_for_farm3_valueXML As XmlNode = xmlReader.SelectSingleNode("//photo[3]/@farm")
            '' had alot of trouble trying to figure out how to set this up to read each element sibling. Had to use innerxml to extract sibling information on the specified path.
            '' see example of return data at top of txtFile1
            'MessageBox.Show("Here is Farm: " + url_builder_for_farm1_valueXML.InnerXml + vbCrLf +
            ' "Here is secret:" + url_builder_for_photo_secret1_value_from_XML.InnerXml + vbCrLf _
            ' + "Server ID: " + url_builder_for_photo_serverID1_value_from_XML.InnerXml + vbCrLf +
            ' "ID :" + url_builder_for_photo_ID1_valueXML.InnerXml)
            '' confirmation that i obtained the desired values needed to request a photo.
            '' now build a url request in this format.
            ' https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}.jpg
            'For Each number As Integer In 1 to 3

            '' having trouble implementing this part within the class because it keeps throwing a null reference exception when trying to make the request when loading 
            '' the xml document to read the web request. I have ran throught the debugger and checked the locals , but i cannot figure out what the problem is?

            Dim url_PhotoRequest1 As String = String.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", url_builder_for_farm1_valueXML.InnerXml,
            url_builder_for_photo_serverID1_value_from_XML.InnerXml, url_builder_for_photo_ID1_valueXML.InnerXml,
            url_builder_for_photo_secret1_value_from_XML.InnerXml)
            Dim url_PhotoRequest2 As String = String.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", url_builder_for_farm2_valueXML.InnerXml,
            url_builder_for_photo_serverID2_value_from_XML.InnerXml, url_builder_for_photo_ID2_valueXML.InnerXml,
            url_builder_for_photo_secret2_value_from_XML.InnerXml)
            Dim url_PhotoRequest3 As String = String.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", url_builder_for_farm3_valueXML.InnerXml,
            url_builder_for_photo_serverID3_value_from_XML.InnerXml, url_builder_for_photo_ID3_valueXML.InnerXml,
            url_builder_for_photo_secret3_value_from_XML.InnerXml)


            '' read from byte stream the images and display that am read into the picturebox 



            ''render this image to an image box to be displayed on a bing maps api. Or look into using Flickrs maps
            '"Copy and paste this link into a browser and see what photo is returned " + url_PhotoRequest)
            '' tried to display to messagebox , but could not click on its contents.
            Dim PhotoRequest1 As WebRequest = WebRequest.Create(url_PhotoRequest1)
            Dim photoResponseStream As Stream = PhotoRequest1.GetResponse.GetResponseStream()
            Dim flickrPhotoFromStream As Image = Image.FromStream(photoResponseStream)
            PictureBox1.Image = flickrPhotoFromStream
            Dim PhotoRequest2 As WebRequest = WebRequest.Create(url_PhotoRequest2)
            Dim photoResponseStream2 As Stream = PhotoRequest2.GetResponse.GetResponseStream()
            Dim flickrPhotoFromStream2 As Image = Image.FromStream(photoResponseStream2)
            PictureBox2.Image = flickrPhotoFromStream2
            Dim PhotoRequest3 As WebRequest = WebRequest.Create(url_PhotoRequest3)
            Dim photoResponseStream3 As Stream = PhotoRequest3.GetResponse.GetResponseStream()
            Dim flickrPhotoFromStream3 As Image = Image.FromStream(photoResponseStream3)
            PictureBox3.Image = flickrPhotoFromStream3
            'error 404 page not found
            '' need a try catch block when i reach this point.
            ''todo get the rest of the elements from the initial response.
            ''NOTE: each web request sent generates a different response of results.
            'catch any exceptions and let me know what is going wrong.
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

'To do

'get lat and long from flickr photos
'add lat and long to stringbuilder for map to get static map with pushpins
'improve flickr gallery/options
'Add enumeration for weather descriptions

'' for me todo create labels that contain latitude and longitude Joe can use to create pushpins  

'' todo also create send +1 button to add a +1 result pages and then get the next iterated page results and display them. 
