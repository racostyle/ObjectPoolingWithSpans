# Object pooling with Span

## Introduction

This project is designed for object pooling. 

### Do I need this?

Not if you don't have a specific performance problem but it won't hurt. Tough if in your game you are only playing, let's say against a few enemies it will work but you will just be overcomplicating for nothing. But when you have 100+ objects then it will be wise, especially if you are creating new arrays. I have not included this since I have just prepared the ground since I know I will need to use it eventually. 

### Limitations and constraints

Due to working with spans, the array size of the objects in the pool is fixed. Because of this, there is a limiter on active objects in the pool that is dynamically increased when needed. As I have said this is all because of spans. They offer a massive advantage in speed and memory allocation but will shit bricks when the array/list they are referring to will have rearranged order, and items removed...

### Technical requirements

You need to manually import 2 packages since Unity is lagging behind:
* `System.Memory` 
* `System.Runtime.CompilerServices.Unsafe`

Pretty much Google "download NuGet package" (you need to download them directly not with NuGet in IDE), then find and download both packages. Rename the file endings to .zip and unzip them. You only need 2 .dll files, best would be in the netstandard 2.0. To import it into the Unity editor just drag and drop them into a folder (don't move them after!) and __UNCHECK__ Validate references in the inspector for both.
![Screenshot_26](https://github.com/racostyle/Whyunoworkx022/assets/10810250/d6fed1a2-db04-4267-b8ab-f82baddf73ea)

### Project structure

There are 3 projects all encapsulating their own use and working as a team

#### ObjectPool

The class was initially made as generic but for simplification, I have included POController for easier access. The object pool remained generic and as such for people with needs and know-how, this is a bonus while the project still remains beginner-friendly for newcomers.
Core pooling logic. The main job is just, and only just, responsibility for object pooling. Look at it, marvel at technology BUT leave it alone. Otherwise, if your game hangs itself and the compiler yells at you, well then it is on you :)

#### POController
`Pooled Object Controller`
 
This class should be added as a component to the object you want to include in the pool. As described in PoolSpawnerMono it will create a gameobject for the pool but the pool itself will only be referencing POController. Take it as "object manager". Whatever you need to access in your object, should be here. I have already included Transform and GameObject but you can add whatever you need like Health, Movement, Collider, Rigidbody.... This is what you should already be doing, since constantly using GetComponent is not great anyway
>WARNING: If you do not know what you are doing this is the only class you should be editing.

#### PoolSPawnerMono

This class should be attached to GameObject. You can also implement it another way but it requires Monobehaviour for installation. 
