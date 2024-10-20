# Task Monitoring Library

## Overview

**Task Monitoring** is a C# library designed to monitor and manage `Task` and `ThreadPool` usage in .NET applications. It provides an API to expose runtime statistics, such as the number of active threads and tasks, and detailed task execution information.

This library is useful for debugging, performance monitoring, and gaining insights into how tasks and threads are managed in your application.

## Features

- Track the number of currently active `ThreadPool` threads.
- Monitor the number of scheduled, running, and completed tasks.
- Expose detailed information about tasks, including their status, start time, and duration.
- Provides an API to access task monitoring data, which can be extended to visualize metrics in charts.

## Installation

You can install this package from NuGet using the .NET CLI:

```bash
dotnet add package TaskMonitoring
