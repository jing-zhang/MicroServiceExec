# MicroServiceExec

Environt set up.
I have using docker to set up rabbitmq and mongodb
Since mongodb still have some issue on windows sides, so it better use docker in linux.

start rabbitmq
docker run -d --hostname my-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management

start sql Server
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssWord' -p 1433:1433 -d microsoft/mssql-server-linux:2017-latest

start mongodb
docker run -d -p 27017:27017 -v ~/data/:/data/db mongo

rabbitmq setup

create exchange name "my_exchange"
create channel name "my_queue"

bind exchange -> my_queue

mongodb setup
create db "local"
create collection "users" under "local"
