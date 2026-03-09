# Get all Contacts

Get all Contacts in the authenticated user's account. The response includes a list of Contacts, each containing details about a Contact.
---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.

---

## Endpoints


`/Contacts`


#### Body

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Authorization` | `string` | Yes | Authorization. |

#### Response
| Name | Type | Description |
| :--- | :--- | :--- |
| `data` | `object[]` | object[]. |
| `error` | `object[]` | object[]. |

#### Example Request

```python
javascript
const options = {method: 'GET', headers: {Authorization: 'Bearer <token>'}};

fetch('https://localhost/Contacts', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));
```

# Search Contact

Search contact in the authenticated user's account. The response includes a Contact, containing details about a Contact.
---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.


## Endpoints


`/Contacts/Name={keyword}`


#### Parameters

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Authorization` | `string` | Yes | Authorization. |
| `keyword` | `string` | Yes | Keyword. |

#### Response
| Name | Type | Description |
| :--- | :--- | :--- |
| `data` | `object` | object. |
| `error` | `object[]` | object[]. |

#### Example Request

```javascript
const options = {method: 'GET', headers: {Authorization: 'Bearer <token>'}};

fetch('https://localhost/Contacts/Name={keyword}', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));