# FileSharingController API Documentation

## Overview

The FileSharingController provides comprehensive file and folder management capabilities for the ClairTourTiny application. It handles file sharing, folder creation, file indexing, and project management operations.

**Base URL**: `/api/FileSharing`

**Content-Type**: `application/json`

---

## Table of Contents

1. [Authentication & Authorization](#authentication--authorization)
2. [File Sharing Operations](#file-sharing-operations)
3. [Folder Management Operations](#folder-management-operations)
4. [File Indexing Operations](#file-indexing-operations)
5. [Project Management Operations](#project-management-operations)
6. [Error Handling](#error-handling)
7. [Response Models](#response-models)
8. [Common Parameters](#common-parameters)

---

## Authentication & Authorization

All endpoints require proper authentication. Ensure you include the necessary authentication headers in your requests.

---

## File Sharing Operations

### 1. Share Selected Folder

Share a folder with a specific member.

**Endpoint**: `POST /api/FileSharing/share-selected`

**Description**: Creates a share request for a specific folder with a designated user.

**Request Body**:
```json
{
  "email": "string",
  "entityNo": "string",
  "cloudFolderTemplate": "string",
  "attachmentCategory": "string",
  "userFolderPath": "string",
  "note": "string"
}
```

**Parameters**:
- `email` (required): Email address of the user to share with
- `entityNo` (required): Entity number associated with the folder
- `cloudFolderTemplate` (required): Cloud folder template (e.g., "PRODUCTION")
- `attachmentCategory` (required): Category of attachment (e.g., "Projects", "Parts")
- `userFolderPath` (required): Full path to the user folder
- `note` (optional): Additional notes for the share request

**Sample Request**:
```json
{
  "email": "john.doe@company.com",
  "entityNo": "12345",
  "cloudFolderTemplate": "PRODUCTION",
  "attachmentCategory": "Projects",
  "userFolderPath": "C:/Projects/Project123",
  "note": "Please review the project documents for approval"
}
```

**Response**:
```json
{
  "message": "Folder shared successfully"
}
```

**Status Codes**:
- `200 OK`: Folder shared successfully
- `400 Bad Request`: Invalid request parameters
- `500 Internal Server Error`: Server error

---

### 2. Share All Folders

Share folders with multiple members.

**Endpoint**: `POST /api/FileSharing/share-all`

**Description**: Creates share requests for multiple folders with multiple users.

**Request Body**: Array of `ShareRequestModel` objects

**Sample Request**:
```json
[
  {
    "email": "user1@company.com",
    "entityNo": "12345",
    "cloudFolderTemplate": "PRODUCTION",
    "attachmentCategory": "Projects",
    "userFolderPath": "C:/Projects/Project123",
    "note": "Project documents for review"
  },
  {
    "email": "user2@company.com",
    "entityNo": "12345",
    "cloudFolderTemplate": "PRODUCTION",
    "attachmentCategory": "Projects",
    "userFolderPath": "C:/Projects/Project123",
    "note": "Project documents for review"
  }
]
```

**Response**:
```json
{
  "message": "Folders shared successfully with all members"
}
```

---

### 3. Remove Selected Access

Remove access for a specific member.

**Endpoint**: `POST /api/FileSharing/remove-selected`

**Description**: Removes folder access for a specific user.

**Query Parameters**:
- `email` (required): Email of the member to remove access for
- `entityNo` (required): Entity number
- `template` (required): Cloud folder template

**Sample Request**:
```
POST /api/FileSharing/remove-selected?email=user@company.com&entityNo=12345&template=PRODUCTION
```

**Response**:
```json
{
  "message": "Access removed successfully"
}
```

---

### 4. Remove All Access

Remove access for all members.

**Endpoint**: `POST /api/FileSharing/remove-all`

**Description**: Removes folder access for all members associated with an entity.

**Query Parameters**:
- `entityNo` (required): Entity number
- `template` (required): Cloud folder template

**Sample Request**:
```
POST /api/FileSharing/remove-all?entityNo=12345&template=PRODUCTION
```

**Response**:
```json
{
  "message": "Access removed successfully for all members"
}
```

---

## Folder Management Operations

### 5. Create Folder

Create a new folder with user-provided name.

**Endpoint**: `POST /api/FileSharing/create-folder`

**Description**: Creates a new folder and validates root folder existence.

**Request Body**:
```json
{
  "newFolderName": "string",
  "attachmentCategorySubFolderPath": "string",
  "attachmentCategory": "string",
  "entityNo": "string",
  "dropboxEnabled": "boolean"
}
```

**Parameters**:
- `newFolderName` (required): Name for the new folder
- `attachmentCategorySubFolderPath` (required): Base path where folder should be created
- `attachmentCategory` (required): Attachment category
- `entityNo` (required): Entity number associated with the folder
- `dropboxEnabled` (optional): Whether Dropbox integration is enabled (default: false)

**Sample Request**:
```json
{
  "newFolderName": "ProjectDocuments",
  "attachmentCategorySubFolderPath": "C:/Projects/Attachments",
  "attachmentCategory": "Projects",
  "entityNo": "12345",
  "dropboxEnabled": true
}
```

**Response**:
```json
{
  "success": true,
  "message": "Folder created successfully",
  "folderPath": "C:/Projects/Attachments/ProjectDocuments"
}
```

---

### 6. Create Folder in Selected Location

Create a new folder in a selected folder location.

**Endpoint**: `POST /api/FileSharing/create-folder-in-selected`

**Description**: Creates a new folder within a specific parent folder location.

**Request Body**:
```json
{
  "newFolderName": "string",
  "currentGlobalOpsFolder": "string",
  "attachmentCategory": "string",
  "entityNo": "string",
  "selectedNodePath": "string",
  "dropboxEnabled": "boolean",
  "isLoadingTree": "boolean"
}
```

**Parameters**:
- `newFolderName` (required): Name for the new folder
- `currentGlobalOpsFolder` (required): Current global operations folder path
- `attachmentCategory` (required): Attachment category
- `entityNo` (required): Entity number associated with the folder
- `selectedNodePath` (optional): Path of the selected node (parent folder)
- `dropboxEnabled` (optional): Whether Dropbox integration is enabled (default: false)
- `isLoadingTree` (optional): Whether the tree is currently loading (default: false)

**Sample Request**:
```json
{
  "newFolderName": "SubProject",
  "currentGlobalOpsFolder": "C:/Projects/Attachments/Project123",
  "attachmentCategory": "Projects",
  "entityNo": "12345",
  "selectedNodePath": "Project123",
  "dropboxEnabled": true,
  "isLoadingTree": false
}
```

**Response**:
```json
{
  "success": true,
  "message": "Folder created successfully in selected location",
  "folderPath": "C:/Projects/Attachments/Project123/SubProject"
}
```

---

## File Indexing Operations

### 7. Add/Update File Index

Add or update file in the search index.

**Endpoint**: `POST /api/FileSharing/index-file`

**Description**: Indexes a file for search functionality with metadata.

**Query Parameters**:
- `filePath` (required): Path of the file to index
- `guid` (required): Current GUID
- `subFolderPath` (required): Subfolder path

**Sample Request**:
```
POST /api/FileSharing/index-file?filePath=C:/Projects/document.pdf&guid=550e8400-e29b-41d4-a716-446655440000&subFolderPath=Project123
```

**Response**:
```json
{
  "message": "File indexed successfully"
}
```

---

### 8. Delete Folder from Index

Delete folder from search index.

**Endpoint**: `DELETE /api/FileSharing/index-folder`

**Description**: Removes a folder and its contents from the search index.

**Query Parameters**:
- `guid` (required): Current GUID
- `subFolderPath` (required): Subfolder path to delete

**Sample Request**:
```
DELETE /api/FileSharing/index-folder?guid=550e8400-e29b-41d4-a716-446655440000&subFolderPath=Project123
```

**Response**:
```json
{
  "message": "Folder deleted from index successfully"
}
```

---

## Project Management Operations

### 9. Get/Create Project Folder GUID

Gets or creates a project folder GUID for a given entity number.

**Endpoint**: `GET /api/FileSharing/project-folder-guid`

**Description**: Retrieves or generates a unique GUID for project folder management.

**Query Parameters**:
- `entityNo` (required): Entity number to get or create GUID for

**Sample Request**:
```
GET /api/FileSharing/project-folder-guid?entityNo=12345
```

**Response**:
```json
{
  "guid": "550e8400-e29b-41d4-a716-446655440000",
  "message": "GUID retrieved successfully"
}
```

---

### 10. Upload All Project Files

Uploads all project files in a folder and its subfolders.

**Endpoint**: `POST /api/FileSharing/upload-all-project-files`

**Description**: Processes and uploads all files within a specified folder structure.

**Request Body**:
```json
{
  "selectedFolderPath": "string",
  "template": "string",
  "attachmentCategory": "string",
  "currentGlobalOpsFolder": "string",
  "currentEntityNo": "string",
  "currentPartNo": "string",
  "selectedFolderAttachmentType": "string"
}
```

**Parameters**:
- `selectedFolderPath` (required): Path of the selected folder
- `template` (required): Template for the project
- `attachmentCategory` (required): Attachment category
- `currentGlobalOpsFolder` (required): Current global operations folder
- `currentEntityNo` (required): Current entity number
- `currentPartNo` (required): Current part number
- `selectedFolderAttachmentType` (optional): Attachment type of the selected folder

**Sample Request**:
```json
{
  "selectedFolderPath": "C:/Projects/Project123",
  "template": "PRODUCTION",
  "attachmentCategory": "Projects",
  "currentGlobalOpsFolder": "C:/Projects/Project123",
  "currentEntityNo": "12345",
  "currentPartNo": "67890",
  "selectedFolderAttachmentType": "DOCUMENT"
}
```

**Response**:
```json
{
  "success": true,
  "message": "All project files uploaded successfully",
  "foldersProcessed": 1,
  "filesProcessed": 1
}
```

---

## Error Handling

### Common Error Responses

**400 Bad Request**:
```json
{
  "success": false,
  "message": "Error description",
  "folderPath": null
}
```

**500 Internal Server Error**:
```json
{
  "success": false,
  "message": "Internal server error description",
  "folderPath": null
}
```

### Error Codes

- `400`: Invalid request parameters or validation failure
- `500`: Internal server error or database connection issues

---

## Response Models

### CreateFolderResponseModel
```json
{
  "success": "boolean",
  "message": "string",
  "folderPath": "string"
}
```

### UploadAllProjectFilesResponseModel
```json
{
  "success": "boolean",
  "message": "string",
  "foldersProcessed": "integer",
  "filesProcessed": "integer"
}
```

### ProjectFolderGuidResponse
```json
{
  "guid": "string",
  "message": "string"
}
```

---

## Common Parameters

### Attachment Categories
- `"Projects"`: Project-related files and folders
- `"Parts"`: Part-related files and folders

### Cloud Folder Templates
- `"PRODUCTION"`: Production environment template
- `"DEVELOPMENT"`: Development environment template
- `"TESTING"`: Testing environment template

### File Types
- `"DOCUMENT"`: Document files
- `"IMAGE"`: Image files
- `"VIDEO"`: Video files
- `"AUDIO"`: Audio files

---

## Usage Examples

### Complete Workflow Example

1. **Create a Project Folder**:
```bash
curl -X POST "https://api.example.com/api/FileSharing/create-folder" \
  -H "Content-Type: application/json" \
  -d '{
    "newFolderName": "NewProject",
    "attachmentCategorySubFolderPath": "C:/Projects/Attachments",
    "attachmentCategory": "Projects",
    "entityNo": "12345",
    "dropboxEnabled": true
  }'
```

2. **Share the Folder**:
```bash
curl -X POST "https://api.example.com/api/FileSharing/share-selected" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "team@company.com",
    "entityNo": "12345",
    "cloudFolderTemplate": "PRODUCTION",
    "attachmentCategory": "Projects",
    "userFolderPath": "C:/Projects/Attachments/NewProject",
    "note": "New project folder for collaboration"
  }'
```

3. **Upload All Files**:
```bash
curl -X POST "https://api.example.com/api/FileSharing/upload-all-project-files" \
  -H "Content-Type: application/json" \
  -d '{
    "selectedFolderPath": "C:/Projects/Attachments/NewProject",
    "template": "PRODUCTION",
    "attachmentCategory": "Projects",
    "currentGlobalOpsFolder": "C:/Projects/Attachments/NewProject",
    "currentEntityNo": "12345",
    "currentPartNo": "67890",
    "selectedFolderAttachmentType": "DOCUMENT"
  }'
```

---

## Best Practices

1. **Authentication**: Always include proper authentication headers
2. **Validation**: Validate all required parameters before making requests
3. **Error Handling**: Implement proper error handling for all API calls
4. **Rate Limiting**: Respect API rate limits and implement retry logic
5. **Logging**: Log API calls for debugging and monitoring purposes

---

## Support

For technical support or questions about this API, please contact the development team or refer to the internal documentation system.

---

**Version**: 1.0  
**Last Updated**: December 2024  
**Maintained By**: ClairTourTiny Development Team 