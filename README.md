# Unity Icon Customizer
You can customize your app icon with this. Like adding version number, 'BETA' and so on.

![UnityIconCustomizer](https://github.com/makoto-unity/Pics/blob/master/UnityIconCustomizer/IconScreenShot2.png?raw=true)

# Dependency
- Unity 
- iOS (Android on WIP)
- Available for Unity Cloud Build

## What's it?

This project include the generator app icon for iOS.
The editor script can create your own icon you want.
You can customize your icon in Unity Editor as you like.

## What's for?

Can you distinguish between release and beta version apps?
If the app icon is same, you must not pick it out.
So, when you can build for beta, it can attatch to beta 'ribon' in your icon. 

## Setup and Usage

1. You can customize IconGenSystem in your project, and apply the prefab.
2. Add define symbols in IconBuilder.cs for version handling as you like.
3. Call IconBuilder.GenerateIconForIOS() or select MyApp/GenerateIconForIOS in Unity editor.
4. It automatically sets all iOS icons.
