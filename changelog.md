# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.0.0-preview.1) - 2021-05-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/3?closed=1)  
    

### Changed

- Add initialization for executer ([#6](https://github.com/unity-game-framework/ugf-coroutines/pull/6))  
    - Update dependencies: add `com.ugf.initialize` of `2.6.0` version.
    - Add `CoroutineExecuterComponent` class to execute coroutines using specified component.
    - Add `CoroutineExecuterGameObject` class to execute coroutines using created gameobject with component.
    - Add `CoroutineExecuterComponentBase` base class to implement coroutine executer which works with Unity components.
    - Change `CoroutineExecuterBase` to implement `InitializeBase` class.
    - Change `ICoroutineExecuter` to implement `IInitialize` interface.
    - Change `CoroutineExecuterUnityComponent` class name to `CoroutineExecuterBehaviour`.
    - Remove `CoroutineExecuterUnity` class, replaced by `CoroutineExecuterComponent` and `CoroutineExecuterGameObject`.
    - Remove `CoroutineRunner.CoroutineRunner(MonoBehaviour component)` constructor.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.0.0-preview) - 2021-05-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/2?closed=1)  
    

### Changed

- Update project ([#4](https://github.com/unity-game-framework/ugf-coroutines/issues/4))  
    - Update project workflows;
    - Update project registry;
    - Update to Unity 2021.1;
    - Rework `Coroutine` and `Coroutine<T>` implementations.
    - Rework `ICoroutineExecuter` and `CoroutineExecuterUnity` classes.
    - Add `CoroutineRunner` class.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/0.1.0-preview) - 2019-09-24  

- [Commits](https://github.com/unity-game-framework/ugf-coroutines/compare/d71fde9...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/1?closed=1)

### Added
- This is a initial release.


