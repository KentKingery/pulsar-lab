package io.acmecode.pulsar;

import org.apache.pulsar.client.api.*;
//import org.apache.pulsar.client.api.MessageBuilder;

public class Main {
    public static void main(String[] args) throws PulsarClientException {
        System.out.println("Pulsar Test Client");

        PulsarClient client = PulsarClient.builder()
                .serviceUrl("pulsar://192.168.86.20:6650")
                .build();

        Consumer consumer = client.newConsumer()
                .topic("persistent://acmecode/lab/partitions")
                .subscriptionName("java-consumer")
                .subscribe();

        while (true) {
            // Wait for a message
            Message msg = consumer.receive();

            try {
                // Do something with the message
                System.out.println("Message received: " + new String(msg.getData()));

                // Acknowledge the message
                consumer.acknowledge(msg);
            } catch (Exception e) {
                // Message failed to process, redeliver later
                consumer.negativeAcknowledge(msg);
            }
        }
    }
}