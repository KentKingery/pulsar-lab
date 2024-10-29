curl http://localhost:7750/pulsar-manager/csrf-token > token
set /P PULSAR_TOKEN=<token
curl -H "X-XSRF-TOKEN: %PULSAR_TOKEN%" -H "Cookie: XSRF-TOKEN=%PULSAR_TOKEN%;" -H "Content-Type: application/json" -X PUT http://localhost:7750/pulsar-manager/users/superuser -d "{""name"": ""admin"", ""password"": ""apachepulsar"", ""description"": ""test"", ""email"": ""username@test.org""}"
