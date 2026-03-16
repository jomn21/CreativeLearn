# Create Contact

Create Contact in the authenticated user's account.
---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.

---

## Endpoints
`POST/v2/contacts`

| `Authorization` | `string` | Yes | Authorization. |


#### Body

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Name` | `string` | Yes | Name. |
| `Age` | `string` | No | Age. |
| `Country` | `string` | No | Country. |
| `Phone` | `string` | No | Phone. |

#### Example Request

```python
javascript
const options = {
  method: 'POST',
  headers: {Authorization: 'Bearer <token>', 'Content-Type': 'application/json'},
  body: JSON.stringify({
    Name: '<string>',
    Age: '<string>',
    Country: '<string>',
    Phone: '<string>'
  })
};


fetch('POST/v2/contacts', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));
```

#### Response
| Name | Type | Description |
| :--- | :--- | :--- |
| `data` | `object` | object. |
| `error` | `object` | `object`. |

#### Example Response

``` "
{
"data": {
    "success": "true"    
  },
  "error": 
    {
      "title": "<string>"
     }
      
  }
  ```
# Search Contact

Search contact in the authenticated user's account. The response includes a Contact, containing details about a Contact.
---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.


## Endpoints


`/Contacts/Name={keyword}`

| `Authorization` | `string` | Yes | Authorization. |

#### Parameters

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `keyword` | `string` | Yes | Keyword. |


#### Example Request

```javascript
const options = {method: 'GET', headers: {Authorization: 'Bearer <token>'}};

fetch('https://localhost/Contacts/Name={keyword}', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));
  ```
#### Response
| Name | Type | Description |
| :--- | :--- | :--- |
| `data` | object | object. |
| `error` | object | object. |

#### Example Response

``` "
{
"data": {
    "Name": "Test",
    "Age": "22",
    "Country": "AU",
    "Phone": "1213"
  },
  "error": 
    {
      "title": "<string>"
     }
      
  }
  ```


