# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.1.0) - 2023-01-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/7?closed=1)  
    

### Added

- Add coroutine runner wait from the task ([#13](https://github.com/unity-game-framework/ugf-coroutines/issues/13))  
    - Update dependencies: `com.ugf.initialize` to `2.9.0` version.
    - Update package _Unity_ version to `2021.3`.
    - Add `CoroutineRunner.RunAsync()` extension method to start coroutine and wait for it end using tasks.

## [1.0.0](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.0.0) - 2022-01-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/6?closed=1)  
    

### Changed

- Update project to Unity 2021 ([#11](https://github.com/unity-game-framework/ugf-coroutines/issues/11))  
    - Update dependencies: `com.ugf.initialize` to `2.7.0` version.
    - Update package _Unity_ version to `2021.2`.
    - Update API compatibility to `.NET Standard 2.1`.

## [1.0.0-preview.3](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.0.0-preview.3) - 2021-08-08  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/5?closed=1)  
    

### Added

- Add coroutine to wait for task with result or not ([#10](https://github.com/unity-game-framework/ugf-coroutines/pull/10))  
    - Add `CreateCoroutine` and `CreateCoroutine<T>` extension methods for `Task` and `Task<T>` classes to create coroutine to wait for task completion.
    - Add `TaskCoroutine` and `TaskCoroutine<T>` classes which works with `Task` and `Task<T>` classes.

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-coroutines/releases/tag/1.0.0-preview.2) - 2021-07-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-coroutines/milestone/4?closed=1)  
    

### Changed

- Change CoroutineExecuterBehaviour component to be hidden ([#8](https://github.com/unity-game-framework/ugf-coroutines/pull/8))  
    - Add `AddComponentMenu` attribute for `CoroutineExecuterBehaviour` with empty path to hide component from _Add Component_ menu in inspector.

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


