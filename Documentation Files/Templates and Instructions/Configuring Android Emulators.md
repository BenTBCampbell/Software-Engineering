# Configuring Android Phone for Visual Studio

Below are the instructions to configure one of our phones, to work with debugging for Visual Studio. For me, this option is pretty fast and since it uses your phone, it should be very accurate and is easy to test/debug.

See also [this article](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/set-up-device-for-development) from Microsoft.

1. <strong>Configure phone for debugging.</strong> To do this, go to settings, find about system, and click build number seven times. Enter your pin and click okay.
2. <strong>Enable USB Debugging.</strong> Go to Settings, System, and find the Developer Options Category. Check the `Enable USB Debugging` Checkbox.
3. <strong>Connect the phone to the computer via USB. </strong> Connect a USB cable from the phone into the computer. The first time, a notification will pop up on the phone, asking for your permission. Check the `Always allow from this computer` checkbox and click OK.
4. Click the Debug dropdown and see if your phone pops up. If not, you may need to install a USB driver for your phone. Look at the manufacturer's website for a USB driver.
<br/><br/>
# Configuring Android Emulator for Visual Studio

## [Installing HAXM (Intel Processors)](https://software.intel.com/content/www/us/en/develop/videos/setting-up-intel-haxm-on-windows.html)

1. Run the following command to see if virtualization is enabled. If not, you may have to change the setting in the BIOS.

```systeminfo```

2. Now open the Android SDK Manager in Visual Studio via Tools, Android, go to the `Tools` section, scroll all the way down to `Extras`, and click the Intel x86 Intel Accelerator.
3. Click `Install Package`.
4. Verify HAXM is installed. Open a command prompt, and type `sc query intelhaxm`. It should say that HAXM is `RUNNING`.

## [Installing Emulator for AMD Processors](https://software.intel.com/content/www/us/en/develop/videos/setting-up-intel-haxm-on-windows.html)

1. Run the following command to see if virtualization is enabled. If not, you may have to change the setting in the BIOS.

```systeminfo```

2. Now open the Android SDK Manager in Visual Studio via Tools, Android, go to the `Tools` section, scroll all the way down to `Extras`, and click the Android Emulator Hypervisor Driver for AMD Processors.
3. Click `Install Package`.
4. Verify the driver is installed. Open a command prompt, go to `$ANDROID_SDK_ROOT\extras\google\Android_Emulator_Hypervisor_Driver`, and type `silent_install.bat`. Make sure it say it is `RUNNING`.

## [Creating the Virtual Device](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/device-manager?tabs=windows&pivots=windows#main-screen)

1. Open the Android Device Manager by going to Tools, Android, Android Device Manager.
2. Be sure to select an x86 system image. Selected an ARM-based system image (x64) will cause the system to run much slower. You can also the x86_64, if you want to test 64-bit apps, but it will be slightly slower.
3. If you wish, [set the properties to their desired values](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/device-properties?pivots=windows).

<div style="background:darkorange; color:white; padding: 10px; margin-bottom:10px; border-radius: 7px">
<p><strong>Warning!</strong></p>
<p>HAXM will not function with more than 4,095 MB of RAM, so make sure the RAM for the emulator is <strong>less</strong> than 4 GB.</p>
</div>

3. Click Okay. If the image is not on your computer, it will be downloaded.

<div style="background:gray; color:white; padding: 10px; margin-bottom:10px; border-radius: 7px">
<p><strong>Information</strong></p>
<p>The first time the emulator loads it will initialize. This will only happen the first time, since it saves the state.</p>
</div>

## [Troubleshooting](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/troubleshooting?pivots=windows)

### Performance is too slow
* <strong>Make sure hardware acceleration is enabled.</strong> If it is not, the program will run much slower. Open a command prompt and type the following:

```"C:\Program Files (x86)\Android\android-sdk\emulator\emulator-check.exe" accel```

If it says HAXM is installed and useable, hardware acceleration via HAXM is working correctly.

Otherwise, you can also type `sc query intelhaxm` to see if HAXM is installed. If it does not say `RUNNING` it is not installed.

* <strong>Use x86 Architecture.</strong> Make sure your Android Virtual Device system image is set to x86.
* <strong>Don't power off the phone.</strong> Once you're done, click the X button or click Stop Debugging in the Visual Studio IDE.
* <strong>Enable fast boot.</strong> Make sure fast boot is enabled in the virtual device properties.

### Emulator won't deploy

* <strong>Try repairing the Emulator.</strong> Go to Tools, Android, and then click Android SDK. Next, click the `Repair` button.
* <strong>Try using a new ARD (Android Virtual Device).</strong> Go to Tools, Android Device Manager, and try creating a new device.

### Project won't build--weird errors
* <strong>Try rebuilding the solution.</strong> Go to Build, Clean Solution. Then try building again.

### Android Device Manager won't load
* <strong>Make sure the correct packages are installed.</strong> See [this article](https://docs.microsoft.com/en-us/xamarin/android/platform/android-10).

### Warning about Target Version
* <strong>Select correct Target Version.</strong> Select the Android Project and then go to Project, [Project Name] Properties. For more information, see [this article](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/android-api-levels?tabs=windows).