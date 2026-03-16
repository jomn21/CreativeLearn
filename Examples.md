
#  1.	Upload URI, for media upload requests:
POST https://www.googleapis.com/upload/drive/v3/files
# 2.	Metadata URI, for metadata-only requests:
## POST https://www.googleapis.com/drive/v3/files
## Query parameters
# Parameters
#### enforceSingleParent
(deprecated)	boolean
Deprecated: Creating files in multiple folders is no longer supported.
#### ignoreDefaultVisibility	boolean
Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.
#### keepRevisionForever	boolean
Whether to set the keepForever field in the new head revision. This is only applicable to files with binary content in Google Drive. Only 200 revisions for the file can be kept forever. If the limit is reached, try deleting pinned revisions.
#### ocrLanguage	string
A language hint for OCR processing during image import (ISO 639-1 code).
#### supportsAllDrives	boolean
Whether the requesting application supports both My Drives and shared drives.
supportsTeamDrives
#### (deprecated)	boolean
Deprecated: Use supportsAllDrives instead.
#### uploadType	string
The type of upload request to the /upload URI. If you are uploading data with an /upload URI, this field is required. If you are creating a metadata-only file, this field isn't required. Additionally, this field isn't shown in the "Try this method" widget because the widget doesn't support data uploads.
Acceptable values are:
�	media - Simple upload. Upload the media only, without any metadata.
�	multipart - Multipart upload. Upload both the media and its metadata, in a single request.
�	resumable - Resumable upload. Upload the file in a resumable fashion, using a series of at least two requests where the first request includes the metadata.
#### useContentAsIndexableText	boolean
Whether to use the uploaded content as indexable text.
#### includePermissionsForView	string
Specifies which additional view's permissions to include in the response. Only published is supported.
#### includeLabels	string
A comma-separated list of IDs of labels to include in the labelInfo part of the response

## Request body
The request body contains an instance of File.
## Response body
If successful, the response body contains an instance of File.


# 3.	POST https://www.googleapis.com/drive/v3/drives

## Query parameters
### Parameters
requestId	string
Required. An ID, such as a random UUID, which uniquely identifies this user's request for idempotent creation of a shared drive. A repeated request by the same user and with the same request ID will avoid creating duplicates by attempting to create the same shared drive. If the shared drive already exists a 409 error will be returned.
Request body
The request body contains an instance of Drive.
Response body
If successful, the response body contains a newly created instance of Drive.
# 4.	POST https://www.googleapis.com/drive/v3/files/{fileId}/comments
## Path parameters
### Parameters
#### fileId	string
The ID of the file.
#### Request body
The request body contains an instance of Comment.
#### Response body
If successful, the response body contains a newly created instance of Comment.
# 5.	POST https://www.googleapis.com/drive/v3/files/{fileId}/permissions

## Path parameters
### Parameters
#### fileId	string
The ID of the file or shared drive.
Query parameters
Parameters
#### emailMessage	string
A plain text custom message to include in the notification email.
enforceSingleParent
#### (deprecated)	boolean
Deprecated: See moveToNewOwnersRoot for details.
#### moveToNewOwnersRoot	boolean
This parameter only takes effect if the item isn't in a shared drive and the request is attempting to transfer the ownership of the item. If set to true, the item is moved to the new owner's My Drive root folder and all prior parents removed. If set to false, parents aren't changed.
#### sendNotificationEmail	boolean
Whether to send a notification email when sharing to users or groups. This defaults to true for users and groups, and is not allowed for other requests. It must not be disabled for ownership transfers.
#### supportsAllDrives	boolean
Whether the requesting application supports both My Drives and shared drives.
#### supportsTeamDrives
(deprecated)	boolean
Deprecated: Use supportsAllDrives instead.
#### transferOwnership	boolean
Whether to transfer ownership to the specified user and downgrade the current owner to a writer. This parameter is required as an acknowledgement of the side effect. For more information, see Transfer file ownership.

useDomainAdminAccess	boolean
Issue the request as a domain administrator.
If set to true, and if the following additional conditions are met, the requester is granted access:
1.	The file ID parameter refers to a shared drive.
2.	The requester is an administrator of the domain to which the shared drive belongs.
For more information, see Manage shared drives as domain administrators.

enforceExpansiveAccess
(deprecated)	boolean
Deprecated: All requests use the expansive access rules.
Request body
The request body contains an instance of Permission.
Response body
If successful, the response body contains a newly created instance of Permission.
# 6.	POST https://www.googleapis.com/drive/v3/files/{fileId}/comments/{commentId}/replies
## Path parameters
### Parameters
#### fileId	string
The ID of the file.
#### commentId	string
The ID of the comment.
#### Request body
The request body contains an instance of Reply.
#### Response body
If successful, the response body contains a newly created instance of Reply.






