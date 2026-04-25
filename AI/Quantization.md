# Quantization - A (very) shallow intro

## Why do we need it

By reducing model size we can run an AI

- embedded in a webapp using the local gpu (webgpu)
- on your phone, etc.,
- on your home automation system
- ... and more

### Some size estimates

#### Small Models

- Gemma 3 1B (1 billion parameters): ~1.5 GB (16-bit), ~1.1 GB (8-bit)
- Gemma 3 4B (4 billion parameters): ~6.4 GB (16-bit), ~4.4 GB (8-bit)

#### Medium Models:

- Mistral-Small-2409 (22 billion parameters): ~60 GB (inference)
- LLaMA 3 8B (8 billion parameters): Requires about 8–16 GB of VRAM

#### Large Models

- Mistral-Large-Instruct-2411 (123 billion parameters): ~250 GB (inference)
- LLaMA 3 70B (70 billion parameters): Can require 48 GB- VRAM, often needing 350–700 GB for efficient operation.

#### Estimating Model Size

- Determine the parameter count of the model you want to use.
- Decide on the precision you will use (e.g., 16-bit or 8-bit).

### Use the following rule of thumb to estimate the size in GB for inference

- For 32-bit precision: You'll need roughly 4 GB of memory per billion parameters. (i.e., 1000M * 4
- For 16-bit precision: You'll need roughly 2 GB of memory per billion parameters. (i.e., 1000M * 2 bytes = 2Gb)
- For 8-bit precision: You'll need roughly 1 GB of memory per billion parameters. (i.e., 1000M * 1 byte = 1Gb)

And this is just for the parameter..
Now add in the weights, biases and activations, we can easily run out of gpu memory which results in running the model on the CPU which is going to be much slower

Quantization helps us reduce the footprint of an AI so it can fit on mobile devices, inside a web app, and on your local gpu

## The downside

There is always a cost with this, its a loss of accuracy, but is it a tolerable loss based on the application domain

E.g., a small inaccuracy can tranlate to completely missing a target, a 0.00001 deviation translates to a several thousand mile (or dollar) miss when multipled by distance, dollars or other scalar quantity

The trick is to know what is good enough

## Neural Network

Simplified view of a network showing weights and activation

![Alt text](./images/ANN-with-4-inputs-2-hidden-layers-with-5-neurons-and-3-outputs-Weights-of-connections.png)

## What are weights and activations (AI generated descriptions)

Weights are numerical values assigned to the connections between neurons in an LLM. They act like coefficients that indicate the importance of a particular input

Weights control the influence of one neuron's output on the input of another. A higher weight means a stronger signal, while a lower weight indicates a weaker signal

Activations are the values or outputs produced by neurons after they process their inputs through an activation function.

Bias refers to systematic errors or prejudices in the predictions of LLMs, often influenced by the characteristics of the training data.

$$b+\sum_{i=1}^{n}(w_ix_i)$$


### Relationship Between Weights and Activations

- Input to Neuron: Input data is fed into a neuron.
- Weighted Sum: The input is multiplied by the connection's weight, and this product is summed up.
- Activation Function: The resulting sum is then passed through an activation function.
- Neuron Output: The output of the activation function is the neuron's "activation," which is then passed to the next layer of the network.


## What is Quantization

Quantization is reducing model size by using fewer bits per parameter for resource limited devices.

For example if you have an 8Gb GPU, and want to offload training on that GPU, then you're constrained by that 8Gb limit.

This means some models will not run. (Shameless plug.. use a mac, the shared ram model really helps with running larger models)

## Upsides of Quantization

- Reduces model size (so it fits on your gpu, mobile device, rasberry pi, etc)
- Increased inference speed
- Lower energy requirements (dont need a power hungry machine... see the mac studio)
- Nvidia is still king here (performance), but with that, large amounts of VRAM are expensive
- A Mac Studio has less performance, but can run much larger models at a far more cost effective price

## Downsides of Quantization

- Loss of accuracy
- Possible loss of performance
- Errors can accumulate through the neural network

There are some ways to reduce this loss, but thats another presenation...

## Common Quantization Techniques

- PT - Post Training Quantization - used to reduce footprint of a trained model. This is quick, but loss of accuracy is an issue
- QAT - Quantization Aware Training - quantization is simulated during the training process - is better than PT
- DQ - Dynamic Quantization - Weights are quantized before hand, and also during training

## How it is done (a very light intro)

![Alt text](./images/FP32.jpg)

![Alt text](./images/FP16-2.jpg)

![Alt text](./images/Chunking%20down%20to%20int8.png)

![Alt text](./images/Chunking%20Down.png)

We first calculate scale factor (s) using:

b is the number of bytes that we want to quantize to (8),

α is the _highest absolute value

Then, we use the s to quantize the input x :

Scale factor / Quantization is:

![Alt text](./images/scale%20factor.jpg)

![Alt text](./images/Calc%20Example.jpg)

The quantized value now required only 8 bits to represent, so a potential 4Gb of FP32 weights can now be shrunk down to 1Gb of 8 bit ints.

Note, FP4 now seems to be a thing (but I need to read up on it)

## References

Images and material taken from:
https://www.maartengrootendorst.com/blog/quantization/

Models (gguf)
https://huggingface.co/models?sort=trending&search=gguf

[Back to readme](README.md)