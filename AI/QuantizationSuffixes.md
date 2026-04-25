# Quantization Suffixes

A quantization suffix indicates the specific compression method used for a large language model (LLM), which balances file size, speed, and accuracy. The most common suffixes are found on GGUF files, a format optimized for running LLMs on CPUs.

## Common suffix elements

Bit-width (Q#)
The number immediately following the Q represents the average number of bits per weight.

- Q8: 8-bit quantization. Offers a balance of quality and size, with accuracy close to the original unquantized model.
- Q6: 6-bit quantization. A good balance between speed, size, and quality.
- Q5: 5-bit quantization. A higher-quality, larger version of the 4-bit method.
- Q4: 4-bit quantization. Offers significant compression, which is crucial for running larger models on devices with limited memory.

## Quantization method

The characters after the bit-width specify the quantization algorithm.

- _0: A legacy quantization method that applies a single scale and zero-point across entire blocks of weights. It is simpler and faster, but less accurate than newer methods.

- _K: The modern "K-quantization" method that uses group-wise quantization, adapting the scale and zero-point for smaller, local blocks of weights. This results in much higher precision with low bit-widths.

## Precision variant

For K-quantizations (_K), an additional letter indicates a variant with different internal block sizes or bit-width mixes to adjust the balance between performance and quality.

- _S (Small): Uses more aggressive compression for the smallest file size and fastest inference, with a minor accuracy trade-off.
- _M (Medium): Offers a recommended balance between model size, speed, and accuracy. It is a very common and popular choice.
- _L (Large): Prioritizes accuracy over a smaller file size, using less aggressive compression.

## Examples decoded

- Q8_0: An 8-bit quantized model using the older, uniform quantization scheme. It is larger than K-variants but has minimal accuracy loss.
- Q4_K_M: A 4-bit quantized model using the modern K-quantization method, with a "medium" balance between size and accuracy. This is a very common and recommended option for general use.
- Q5_K_S: A 5-bit model using the K-quantization method, optimized for a smaller size.

An example from hugging face:

https://huggingface.co/QuantStack/Wan2.2-Animate-14B-GGUF

[Back to Quantization](Quantization.md)