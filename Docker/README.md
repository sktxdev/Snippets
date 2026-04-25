# Kafka useful commands

## Create topic

``` bash
# open shell in docker
docker exec -it kafka /bin/bash

# create topic
/opt/kafka/bin/kafka-topics.sh --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic my-topic

# list topics
/opt/kafka/bin/kafka-topics.sh --list --bootstrap-server localhost:9092

```
# Docker compose files

| Name | OS | Notes |
| ---- | -- | ----- |
| azurite/docker-compose-azurite.yml | Windows & Mac | Azure blob storage for local testing |
| sqlserver/docker-compose-sqlserver.yml | Windows | |
| sqledge/docker-compose-sqledge.yml | Mac | |
| postgres/docker-compose-postgres.yml | Windows & mac| |
| mongo/docker-compose-mongo.yml | Windows & Mac | |
| kafka/docker-compose-kafka.yml | Windows & Mac | |
| everything/docker-compose-all.yml | Windows & Mac | Launches everything - this is probably overkill |

