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
