package io.acmecode.pulsar;

import org.apache.pulsar.client.api.CompressionType;
import org.apache.pulsar.client.api.Message;
//import org.apache.pulsar.client.api.MessageBuilder;
import org.apache.pulsar.client.api.MessageId;
import org.apache.pulsar.client.api.Producer;
import org.apache.pulsar.client.api.PulsarClient;
import org.apache.pulsar.client.api.PulsarClientException;
public class Main {
    public static void main(String[] args) throws PulsarClientException {

        System.out.println("Pulsar Test Client");

        PulsarClient client = PulsarClient.builder()
                .serviceUrl("pulsar://192.168.86.20:6650")
                .build();

        Producer<byte[]> producer = client.newProducer()
                .topic("persistent://acmecode/lab/partitions")
                .create();

        for (int i = 0; i < 10; i++){
            producer.send(("newtest #" + i ).getBytes());
        }

    }
}