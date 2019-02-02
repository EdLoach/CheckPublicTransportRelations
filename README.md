# CheckPublicTransportRelations
Tool to help me compare OSM PTv2 bus route data to TNDS opendata to see what needs updating

When first run you will need to populate Options, Settings with appropriate values. The Overpass ones shouldn't need changing, but you will need to set the bounding box (which defaults to one that contains the Tendring district of Essex) the local folder you want to use as the main working folder, and your credentials for downloading the Traveline National Dataset (TNDS) - if you've not got credentials you can register at https://www.travelinedata.org.uk/traveline-open-data/traveline-national-dataset/ (data is OGLv3 licenced).

Once populated, use File, Refresh Bus Stops to download all the nodes within the defined bounding box which have the naptan:AtcoCode tag - this was chosen as it is needed for the matching. The file is stored as a .json file in the AppData folder and read at startup if present. If bus routes are up-to-date then new stops are rare so this won't need refreshing very often. 

The next step is to download the latest TNDS files - use File, Download TNDS to download all files from their ftp site (using the credentials you entered in the Settings table) to the working folder you specified. It will over-write what is already there. Based on my experience of trying to maintain local routes manually, changes to Essex routes get emailed monthly, although this data is refreshed weekly according to https://data.gov.uk/dataset/traveline-national-dataset/resource/d33aac24-e7bb-4401-997d-1b494f53ebd9 - I'd recommend just downloading this when you want to check for changes and make all the required updates before changing again (mainly for my future plans for this tool). For the file transfer I switched early in development from using .NET ftp stuff to WinSCP to support resuming downloads much easier (I was doing initial tests on a faulty ASDL connection only getting about 1Mbps).

Once you have all the files File, Extract Local Routes will extract all .xml files for routes which contain any ATCO Codes matching those from the OSM data downloaded previously to a subfolder of the working folder based on the extract date (my future plans include comparing the latest extract to the previous extract to filter the files further to only need to check ones where there have been changes). This is summarised on the TNDS tab of the application.

Once we know which services intersect our area we can then download the OpenStreetMap data which is another Overpass query (note: this means there may be a lag before you uploading changes and them being available in a refresh of the download data to see if your fixes have worked). This downloads to a .json file which is again loaded at startup if present. It checks for relations intersecting the bbox tagged with route=bus, and does some recursion to get up to the route master relation and down to the member ways and nodes. The route masters are summarised on the OSM tab of the application. 

After extracting local routes or downloading OpenStreetMap data, the app then compares the data, which tries to match first on Operator, Service number and the number of Route Variants, then on operator and service, then just on service. These results are on the Services tab. For those where Operator and Service number (at least) match it then tries further comparison of the route variants and puts the results on the Routes tab.

For correcting the data you'll first want to make sure that operator and service number on the route_master relation in OSM match what is in the TNDS data, so you can then go on to checking the route variants. On the routes tab you can see lists of stops for the first row selected with an OSM list of stops and the first row selected with a TNDS list of stops. This allows you to highlight an existing openstreetmap route and find the changed TNDS route that corresponds (initial use found for example extra stops added near new housing estate, or stopping at a different stop where there was a choice at railway stations or on a high street). A red font was added to make it clearer where the first non-match is after I failed to spot a one character difference when comparing two lists of 44 stops without the visual help. Click on an AtcoCode in either datagrid and click Ctrl-C to copy to clipboard (to allow search by AtcoCode in JOSM for example).

My hope is that I can run this monthly and keep local routes up-to-date.

Unfortunately this doesn't make the task of adding services or route variants for the first time any easier. In my initial tests I found a number of services I've added that have since been cancelled (I live near the coast - some are summer only), and a number of new services that intersect the bbox that I've probably missed previously (or I filtered OSM stops based on a boundary rather than a bbox). These are obvious as they appear towards the bottom on the OSM tab.

The NapTan Stops.csv can be useful for finding details of new bus stops that feature in routes from the TNDS information. That is available from here:
https://data.gov.uk/dataset/ff93ffc1-6656-47d8-9155-85ea0b8f2251/national-public-transport-access-nodes-naptan
Since writing the above, I've added an option to download the Naptan stops and they are used to compare names between OSM and NapTan with a few hard-coded rules that work for me locally (ignore stuff after an opening bracket, or anything after " - " except for "Co - Op", and expand abbreviations found in NapTan such as Rdbt Rd Ave etc). I'm still considering adding something to validate stop area names match updated stop names.

<h2>WinSCP</h2>

This utility uses WinSCP for ftp transfers. WinSCP.exe is licenced GPL 3 and WinSCPnet.dll is licenced MPL 2.0 - details available at https://winscp.net/eng/docs/license
