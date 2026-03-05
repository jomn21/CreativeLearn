# Create or Edit Post

Creates a new Post for the authenticated user, or edits an existing Post when edit_options are provided.

---

## Authorizations

The access token received from the authorization server in the OAuth 2.0 flow.

---

## Endpoints


`POST/2/tweets`


#### Parameters


| Name | Type | Required | Description |
| :--- | :--- | :--- | :--- |
| `Authorization` | `string` | Yes | Authorization. |
| `card_uri` | `string` | No | Card Uri Parameter. This is mutually exclusive from Quote Tweet Id, Poll, Media, and Direct Message Deep Link.
. |
| `community_id` | `string` | No | The unique identifier of this Community. |
| `direct_message_deep_link` | `string` | No | Link to take the conversation from the public timeline to a private Direct Message.
. |

#### Example Request

```javascript
const options = {
  method: 'POST',
  headers: {Authorization: 'Bearer <token>', 'Content-Type': 'application/json'},
  body: JSON.stringify({
    card_uri: '<string>',
    community_id: '1146654567674912769',
    direct_message_deep_link: '<string>',
    edit_options: {previous_post_id: '1346889436626259968'},
    for_super_followers_only: false,
    geo: {place_id: '<string>'},
    media: {media_ids: ['1146654567674912769'], tagged_user_ids: ['2244994945']},
    nullcast: false,
    poll: {duration_minutes: 5042, options: ['<string>'], reply_settings: 'following'},
    quote_tweet_id: '1346889436626259968',
    reply: {
      in_reply_to_tweet_id: '1346889436626259968',
      auto_populate_reply_metadata: true,
      exclude_reply_user_ids: ['2244994945']
    },
    reply_settings: 'following',
    share_with_followers: false,
    text: 'Learn how to use the user Tweet timeline and user mention timeline endpoints in the X API v2 to explore Tweet\u2026 https:\/\/t.co\/56a0vZUx7i'
  })
};

fetch('https://api.x.com/2/tweets', options)
  .then(res => res.json())
  .then(res => console.log(res))
  .catch(err => console.error(err));

