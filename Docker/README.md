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
| docker-compose-sqlserver.yml | Windows | |
| docker-compose-postgres.yml | Windows & mac| |
| docker-compose-mongo.yml | Windows & Mac | |
| docker-compose-kafka.yml | Windows & Mac | |
| docker-compose-all.yml | Windows & Mac | Launches everything - this is probably overkill |

