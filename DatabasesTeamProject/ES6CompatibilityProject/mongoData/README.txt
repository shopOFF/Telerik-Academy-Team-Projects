Put JSON files in mongoDB folder (C:\Program files\MongoDB\Server\3.2\bin)


From CMD

to import from JSON
C:\Program files\MongoDB\Server\3.2\bin> mongoimport.exe /d ES6-data /c Features features.json
C:\Program files\MongoDB\Server\3.2\bin> mongoimport.exe /d ES6-data /c Platforms platforms.json

to export:
C:\Program files\MongoDB\Server\3.2\bin> mongoexport.exe /d ES6-data /c Features /o features.json
C:\Program files\MongoDB\Server\3.2\bin> mongoexport.exe /d ES6-data /c Platforms /o platforms.json