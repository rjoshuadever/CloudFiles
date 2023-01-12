# CloudFiles

This API utilizes SwaggerUI, so you can "try it out"!

CloudFiles is a simple CRUD API that allows a user to host his own files on a database created in their server directory, using SQLite. 

Files are stored as byte[], converted from base64 string, and returned as a Base64 converted string in the Content field. 
Caller is responsible for proper encoding and decoding to and from base64.

Each endpoint is designed to utilize the REST verb for routing, so please ensure proper verbs are used when submitting calls.
Below you will find a more details about the endpoints along with sample objects, but here is a summary with useful notes. Happy Clicking!

GET All files

  ​/api​/UserFiles

Get one file, by ID

  ​/api​/UserFile​/{Id}

POST - Add a file

  ​/api​/UserFile​/api​/AddFile
  
PUT - Updating a file
**NOTE: if the content of a file is updated, a new record will be created in the db, and the old file will still exist as a previous version.**
**Versions increment by 1 automatically with every iteration**
**If you only modify the file details but do not change the content, it will not create a new version, but the current version will be updated with your changes**
  
  ​/api​/UserFile

DELETE
**Caution, this is currently a HARD DELETE, your file will be gone forever.**

​/api​/UserFile​/{Id}

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

DETAILS: 
Generated from Swagger UI

CloudFiles v1
CloudFiles
 1.0 
 
GET
​/api​/UserFiles
Parameters

Responses
Code	Description	Links
200	
Success

Media type

text/plain
Controls Accept header.
Example Value
Schema
[
  {
    "id": 0,
    "name": "string",
    "description": "string",
    "version": "string",
    "previousVersionId": 0,
    "content": "string"
  }
]
No links

GET
​/api​/UserFile​/{Id}

Parameters
Name	Description
Id *
integer($int32)
(path)	
Id
Responses
Code	Description	Links
200	
Success

Media type

text/plain
Controls Accept header.
Example Value
Schema
[
  {
    "id": 0,
    "name": "string",
    "description": "string",
    "version": "string",
    "previousVersionId": 0,
    "content": "string"
  }
]
No links

DELETE
​/api​/UserFile​/{Id}

Parameters

Name	Description
Id *
integer($int32)
(path)	
Id
Responses
Code	Description	Links
200	
Success

Media type

text/plain
Controls Accept header.
Example Value
Schema
[
  {
    "id": 0,
    "name": "string",
    "description": "string",
    "version": "string",
    "previousVersionId": 0,
    "content": "string"
  }
]
No links

POST
​/api​/UserFile​/api​/AddFile
Parameters
Try it out
No parameters

Request body

application/json
Example Value
Schema
{
  "id": 0,
  "name": "string",
  "description": "string",
  "version": "string",
  "previousVersionId": 0,
  "content": "string"
}
Responses
Code	Description	Links
200	
Success

No links

PUT
​/api​/UserFile
Parameters
Try it out
No parameters

Request body

application/json
Example Value
Schema
{
  "id": 0,
  "name": "string",
  "description": "string",
  "version": "string",
  "previousVersionId": 0,
  "content": "string"
}
Responses
Code	Description	Links
200	
Success

Media type

text/plain
Controls Accept header.
Example Value
Schema
{
  "id": 0,
  "name": "string",
  "description": "string",
  "version": "string",
  "previousVersionId": 0,
  "content": "string"
}
No links

Schemas
UserFileDto

id	integer($int32)
name	string
nullable: true
description	string
nullable: true
version	string
nullable: true
previousVersionId	integer($int32)
content	string
nullable: true

