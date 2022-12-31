# FPSOptimizer

A Unity script for optimizing performance by dynamically adjusting graphics settings when the frame rate falls below a target value.

## How to use

1. Add the `FPSOptimizer` script to a GameObject in your Unity scene.
2. Assign the desired target frame rate and check interval in the Inspector.
3. Modify the `Optimize` function to include your own optimization conditions based on the value of the `condition` parameter.

## Customizing optimization conditions

The `Optimize` function in the `FPSOptimizer` script takes a boolean `condition` as a parameter. When `condition` is `true`, you can include any optimization conditions that you want to improve performance. When `condition` is `false`, you can include any conditions to restore the original settings.

For example, you might want to reduce the number of particles in particle systems, downgrade shadows, or disable certain objects when `condition` is `true`. You can then restore the original number of particles, shadow quality, and enabled objects when `condition` is `false`.

Note: The `FPSOptimizer` script is designed to be flexible and customizable, so you can optimize a variety of parameters based on the target frame rate. The included particle system and shadow optimization code is just one example of how the script can be used. You can modify or remove these optimizations as needed for your project and add your own optimizations as desired.

## License

Copyright (c) 2022 Robert Rumney. Licensed under the MIT License. You are free to use this script as you please.
