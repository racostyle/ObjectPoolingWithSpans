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

![285054200-d6fed1a2-db04-4267-b8ab-f82baddf73ea](https://github.com/racostyle/ObjectPoolingWithSpans/assets/10810250/fc2eb746-16d8-4f07-a9df-573c67af4e98)

### Classes

#### ObjectPool

The class was initially made as generic but for simplification, I have included POController for easier access. The object pool remained generic and as such for people with needs and know-how, this is a bonus while the project still remains beginner-friendly for newcomers.
Core pooling logic. The main job is just, and only just, responsibility for object pooling. Dont change this, otherwise, if your game hangs itself and the compiler yells at you, well, then it is on you :)

#### POController
`Pooled Object Controller`
 
This class should be added as a component to the object you want to include in the pool. As described in PoolSpawnerMono it will create a gameobject for the pool but the pool itself will only be referencing POController. Take it as "object manager". Whatever you need to access in your object, should be here. I have already included Transform and GameObject but you can add whatever you need like Health, Movement, Collider, Rigidbody.... This is what you should already be doing, since constantly using GetComponent is not great anyway
>WARNING: If you do not know what you are doing this is the only class you should be editing.

#### PoolSpawnerMono

This class should be attached to GameObject. You can also implement it another way but it requires Monobehaviour for installation. For example, You would attach this to EnemyManager which would also instantiate `ObjectPool`. `ObjectPool` and `PoolSpawnerMono` are working together

## How to use

* Instantiating pool
```csharp
 _pool = new ObjectPool<POController>();
_pool.Init(
    (GameObject)Resources.Load("Enemy/Enemy"), //this is reference to a gameobject you will be instantiating. YOu dont need to use Resources you can just pass a GameObject
    GetComponent<PoolSpawnerMono>(), //Will do actual instantiation, described above
    _enemyContainer, //just an empty object in the sceen to where "Enemies" will be instantiated to
    30, //Max enemies. This is the pool maximum size
    10); //Pool increciment, this is for how much the pool will be increased when needed up to maximum
```
* How to get object from pool
`_pool.GetObjectsInPool()[i]`






