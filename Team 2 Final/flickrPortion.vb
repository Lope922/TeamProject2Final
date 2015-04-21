﻿Imports System.IO
Imports System.Net
Imports System.Xml

Public Class flickrPortion

    Private urlRequestList As ArrayList

    '' here is where are the flickr interation will be 

    '' for flikr i will need a web request for the city and state search built on these qualities. 

    '' this returns the string built ready to be sent. NO ERROR CHECKING PRIOR. 
    Public Function searchSettings() As String
        ' use this base url to generate a request. Replace api_ key with my api key 
        '       URL: https://api.flickr.com/services/rest/?method=flickr.photos.search
        '&api_key=2c33c4c48c9fa2f189c0c08e45be9322
        '&tags=St.+Louis%2C+mo+%2C+landmark%2C+landmarks%2C+neat%2C+places+to+go
        '&has_geo=1
        '&per_page=6&page=1
        '&format=rest
        Try
            '' basu url used to search for photos 
            Dim baseURL As String = "https://api.flickr.com/services/rest/?method=flickr.photos.search"
            '' my apps api key
            Dim apiKey As String = "&api_key=efdd3ce6e251f57b82269e4f3855755b"
            '' use this search tag. City still needed to be replaced with text box info. using the properties defined by Joe
            Dim searchTags As String = "&tags=St.+Louis%2C+mo+%2C+landmark%2C+landmarks%2C+neat%2C+places+to+go"
            ' request photos that have geo locations
            Dim getPhotos_with_geoLoations = "&has_geo=1"
            '' combines both the search for photos per page and number of pages returned
            Dim photosPerPage = "&per_page=6&page=1"
            Dim responseFormat = "&format=rest"

            '' this string built represents all the components needed for the form. some defined. some derived from user input. 
            Dim stringBuilt As String = (baseURL + apiKey + searchTags + getPhotos_with_geoLoations + photosPerPage + responseFormat)
            Return stringBuilt
            Console.WriteLine("Here is the string built: youll find this under output " + stringBuilt)
            'MessageBox.Show("Here is the string built " + stringBuilt)
        Catch ex As Exception
            MessageBox.Show("this problem was thrown while trying to create a web request. Maybe missing a city or state.")
        End Try
    End Function
    '' this does not return an exception on all paths. WHY?



    '' this function needs access to the search settings because that is what they need to be sent as. May want to consider renaming. 
    'ACCEPTS: SEARCHSETTINGS == STRING URLBUILT WITH SEARCH SETTINGS DEFINED WITHIN THE URL 
    'RETURNS: AN XMLDOCUMENT WITH A RESPONSE FROM THE WEBSITE. 
    Public Function send_request_for_photos(searchsettings As String) As XmlDocument
        '' this function will return the photos as a stream because that is how i want to read them in order to be able to print to each photo box 

        ' create the web request first 
        Dim User_request As String = searchsettings

        Dim flickrInitialrequest As WebRequest = WebRequest.Create(User_request)



        '' step 1 create the stream from photos 
        Dim xmlResponse As Stream = flickrInitialrequest.GetResponse.GetResponseStream()

        Dim xmlflickrReader As New XmlDocument
        xmlflickrReader.Load(xmlResponse)


        ' Save the document to a file. White space is 
        '   preserved (no white space). = true 
        xmlflickrReader.PreserveWhitespace = False '' set to false to preserve the same format as formatted response 
        xmlflickrReader.Save("flickrinitialRequest.txt") '' save the document in the debugger and use response to practice extracting

        '' save the response to a document called.. and read it 
        '' get the filewriter
        'Dim file As System.IO.StreamWriter
        ' '' write the file to a file with the file name 
        'file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\Lope\Desktop\FirstBreakPoint.txt", True)
        'file.WriteLine(xmlResponse)
        'file.Close()
        '' now save to a file to see what is being written and also confirm. then search through and sort the info needed with the next loop to be created

        '' don't forget to close the connection 
        xmlResponse.Close()

        '' todo create the loop that loops through the data and saves/ maps them. Think about using a hashtable or hashmap. It could be useful here plus i need the practice.

        Return xmlflickrReader
        '' this is where i am stuck and may need to refer to a hashmap 
    End Function

    '' get the info and return it either as an arraylist. Next create a method to read from the arraylist and make the requests for images. 
    Public Sub extractInfoFromStream(urlRequestList As ArrayList)
        Try
            '' read from the stream 
            Dim xmlResponseDocument As New XmlDocument
            xmlResponseDocument.Load("flickrinitialRequest.txt")




            'doc.Load("C:\Users\Lope\Desktop\flickrinitialRequest.xml")

            '' so for each element for a photo request create a request. 

            '' declare the location of each node that i accessed to request a photo.

            For node_in_nodeLIst As Integer = 1 To 6 Step 1

                '' lets try an enhanced for loop 

                '' or maybe even a hashmap. 
                Dim secret As XmlNode = xmlResponseDocument.SelectSingleNode("//photo/@secret")

                Dim secreStringformat As String = String.Format("//photo[{0}]/@secret", node_in_nodeLIst)

                Dim othersecretnodes As XmlNode = xmlResponseDocument.SelectSingleNode(secreStringformat)
                '' now that the innnertext from that node and save it to request a photo. 

                Dim farm As XmlNode = xmlResponseDocument.SelectSingleNode("//photo/@farm")
                Dim farmStringformat As String = String.Format("//photo[{0}]/@farm", node_in_nodeLIst)
                Dim otherfarmnodes As XmlNode = xmlResponseDocument.SelectSingleNode(farmStringformat)

                Dim server As XmlNode = xmlResponseDocument.SelectSingleNode("//photo/@sever")
                Dim serverStringFormat As String = String.Format("//photo[{0}]/@server", node_in_nodeLIst)
                Dim otherservernodes As XmlNode = xmlResponseDocument.SelectSingleNode(serverStringFormat)

                Dim photoid As XmlNode = xmlResponseDocument.SelectSingleNode("//photo/@id")
                Dim photoidStringformat As String = String.Format("//photo[{0}]/@id", node_in_nodeLIst)
                Dim otherphotoIDnodes As XmlNode = xmlResponseDocument.SelectSingleNode(photoidStringformat)

                If node_in_nodeLIst = 1 Then

                    '' this is the inital request because it won't reqeust the write node for each value. 
                    Dim urlCreator As String
                    urlCreator = String.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", farm.InnerText, server.InnerText, photoid.InnerText, secret.InnerText)

                    '' need to create an arraylist to store the urls that will be sent as request. 

                    urlRequestList.Add(urlCreator)

                    '' may want to end this function here when it returns an arraylist of the urls builts to send the requests for the photo stream. 
                Else

                    Dim evolvingUrlCreator As String
                    evolvingUrlCreator = String.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", otherfarmnodes.InnerText, otherservernodes.InnerText, otherphotoIDnodes.InnerText, othersecretnodes.InnerText)

                    urlRequestList.Add(evolvingUrlCreator)

                    'Dim sendfirstURL As WebRequest = WebRequest.Create(urlCreator)


                    '' figure out how to create the web request and read the response stream into each picture box in the form. LOOK INTO STREAMS AND WHY THIS ISN'T WORKING. 

                    '' create a stream to handle the return of flow of pictures that is about to happen, and then don't forget to close it. 

                    ' Dim flickrPhotoSearchResultsResponseStream As Stream = sendfirstURL.GetResponse.GetResponseStream()

                    '                   Dim firstphoto As Image = Image.FromStream(flickrPhotoSearchResultsResponseStream)



                End If


            Next
            For Each urlrequest As String In urlRequestList
                Console.WriteLine(urlrequest)
            Next

            '' now for each node in nodelist create web reqeust using the formate above and 

            '  MessageBox.Show("Here is the secret test" + secret.ToString)

            ' Return secret
            'MessageBox.Show("Here:" + secret.ToString)

        Catch xmlpath As XmlException
            MessageBox.Show("problem requesting nodes. Contact developer ")
        End Try
        '  Dim nodeList As XmlNodeList

        'Dim root As XmlNode = doc.DocumentElement
    End Sub


End Class
