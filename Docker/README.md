# Kafka useful commands

## Create topic

``` bash
# open shell in docker
docker exec -it kafka /bin/bash

# create topic
kafka-topics --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic my-topic

# list topics
kafka-topics --list --bootstrap-server localhost:9092

```
