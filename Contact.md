# Get all Contacts

Get all Contacts in the authenticated user's account. The response includes a list of Contacts, each containing details about a Contact.
---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.

---

## Endpoints


`/Contacts`


#### Parameters

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Authorization` | `string` | Yes | Authorization. |

#### Example Request

```python
javascript
const options = {method: 'GET', headers: {Authorization: 'Bearer <token>'}};

fetch('https://localhost/Contacts', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));
```

## Endpoints


`/Contacts/{keyword}`


#### Parameters

| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Authorization` | `string` | Yes | Authorization. |
| `keyword` | `string` | Yes | Keyword. |

#### Example Request

```javascript
const options = {method: 'GET', headers: {Authorization: 'Bearer <token>'}};

fetch('https://localhost/Contacts/{keyword}', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));