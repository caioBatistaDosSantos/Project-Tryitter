# Project: Blogs API
# π Collection: User 


## End-point: Login
### Method: POST
>```
>https://localhost:7114/Login
>```
### Body (**raw**)

```json
{
    "Email": "agentep@gmail.com",
    "Password": "123456"
}
```


β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: ListAllUsers
### Method: GET
>```
>https://localhost:7114/User
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2NzgzODc2MCwiZXhwIjoxNjY3ODQyMzYwLCJpYXQiOjE2Njc4Mzg3NjB9.M2lY_mOXT4MIu_oY3GMX0U-hv6M8Od4-LQouV-Fe8Cg|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: CreateUser
### Method: POST
>```
>https://localhost:7114/User
>```
### Body (**raw**)

```json
{
  "name": "Kick Buttowski",
  "email": "kick@gmail.com",
  "password": "123456",
  "module": "Backend",
  "status": "FaΓ§a um pouco e depois faΓ§a mais."
}
```


β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: UpdateUser
### Method: PUT
>```
>https://localhost:7114/User/5
>```
### Body (**raw**)

```json
{
  "name": "Clarence Francis",
  "email": "francis@gmail.com",
  "password": "123456",
  "module": "Frontend",
  "status": "Desistir nΓ£o estΓ‘ no meu vocabulΓ‘rio."
}
```

### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: DeleteUser
### Method: DELETE
>```
>https://localhost:7114/User/5
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: ListUserById
### Method: GET
>```
>https://localhost:7114/User/4
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β
# π Collection: Post 


## End-point: ListAllPosts
### Method: GET
>```
>https://localhost:7114/Post
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2NzY5MTgyNSwiZXhwIjoxNjY3Nzc4MjI1LCJpYXQiOjE2Njc2OTE4MjV9.vF5cLnhGxxP66Ua3b65RDm_RulPmW7R3zISp8UunoAc|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: CreatePost
### Method: POST
>```
>https://localhost:7114/Post
>```
### Body (**raw**)

```json
{
  "urlImage": "https://www.google.com/url?sa=i&url=https%3A%2F%2Fdisney.com.br%2Fdisney-momentos-magicos%2Fcomo-desenhar-phineas-e-ferb&psig=AOvVaw38JEIrjEvcbt7VWWHvOGXK&ust=1667778881429000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCKiv7dCemPsCFQAAAAAdAAAAABAE",
  "content": "O que nΓ³s vamos fazer hoje?",
  "publishedAt": "2022-11-05T23:54:11.034Z",
  "updatedAt": "2022-11-05T23:54:11.034Z"
}
```

### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2NzY5NjM0MiwiZXhwIjoxNjY3NzgyNzQyLCJpYXQiOjE2Njc2OTYzNDJ9.5-lLwvgTl8AM6rF_YCuzYCLILKvHMV85L6rAa1DeCgw|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: GetPostById
### Method: GET
>```
>https://localhost:7114/Post/4
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2NzY5NjM0MiwiZXhwIjoxNjY3NzgyNzQyLCJpYXQiOjE2Njc2OTYzNDJ9.5-lLwvgTl8AM6rF_YCuzYCLILKvHMV85L6rAa1DeCgw|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: ListAllPostsByUserId
### Method: GET
>```
>https://localhost:7114/Post/all/4
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2NzY5NzA0NiwiZXhwIjoxNjY3NzgzNDQ2LCJpYXQiOjE2Njc2OTcwNDZ9.POx7GQNBrPrNgdh3UjIbSlk1FjE9XYfYjVg7CeaNSO8|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: GetLastPostFromUserLogged
### Method: GET
>```
>https://localhost:7114/Post/me/last
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: RemovePost
### Method: DELETE
>```
>https://localhost:7114/Post/5
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: UpdatePost
### Method: PUT
>```
>https://localhost:7114/Post/5
>```
### Body (**raw**)

```json
{
  "urlImage": "https://www.google.com/url?sa=i&url=https%3A%2F%2Fdisney.com.br%2Fdisney-momentos-magicos%2Fcomo-desenhar-phineas-e-ferb&psig=AOvVaw38JEIrjEvcbt7VWWHvOGXK&ust=1667778881429000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCKiv7dCemPsCFQAAAAAdAAAAABAE",
  "content": "VocΓͺs estΓ£o fritos!"
}
```

### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β

## End-point: GetLastPostFromOthersUser
### Method: GET
>```
>https://localhost:7114/Post/last/1
>```
### π Authentication bearer

|Param|value|Type|
|---|---|---|
|token|eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNCIsIm5iZiI6MTY2Nzc3NDYwOCwiZXhwIjoxNjY3ODYxMDA4LCJpYXQiOjE2Njc3NzQ2MDh9.veNBtIerNKAYiMAAUIiZzUiSQc0TMALPsRihM0fnW3Y|string|



β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β β
_________________________________________________
Powered By: [postman-to-markdown](https://github.com/bautistaj/postman-to-markdown/)
