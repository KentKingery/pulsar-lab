package main

import (
	"context"
	"fmt"
	"log"
	"os"
	"time"

	"github.com/apache/pulsar-client-go/pulsar"
)

func main() {
    client, err := pulsar.NewClient( pulsar.ClientOptions {
        URL:               "pulsar://192.168.86.20:6650",
        OperationTimeout:  30 * time.Second,
        ConnectionTimeout: 30 * time.Second,
		},	
	)

    if err != nil {
        log.Fatalf("Could not instantiate Pulsar client: %v", err)
    } else {
		log.Println("Pulsar client instantiated")
	}

	producer, err := client.CreateProducer(pulsar.ProducerOptions{
    	Topic: "persistent://acmecode/lab/general.notify",
	})

	if err != nil {
    	log.Fatal(err)
	}

	_, err = producer.Send(context.Background(), &pulsar.ProducerMessage{
    	Payload: []byte(os.Args[1]),
	})

	defer producer.Close()

	if err != nil {
    	fmt.Println("Failed to publish message", err)
	}
	fmt.Println("Published message")

    defer client.Close()
}