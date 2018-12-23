# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

- ...

## [0.6.3] - 2018-12-23
- Fixed: Paths with spaces were handled incorrectly

## [0.5.0] - 2018-12-22
- Initial implementation.
- Added: Support for simple Citavi arguments, i.e. `/A "page=5" "C:\some\file path.pdf"`
- Added: Support for more elaborate Adobe style argumens, e.g. `/A "page=5&everything=else" "C:\some\file path.pdf"`
- Added: Support for simple delegation of anything that does not start with `/A`