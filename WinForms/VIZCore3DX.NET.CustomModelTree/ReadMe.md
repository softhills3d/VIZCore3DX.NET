# VIZCore3DX.NET.CustomModelTree

## 개요
`VIZCore3DX.NET.CustomModelTree` 프로젝트는 VIZCore3DX.NET 라이브러리를 사용하여 3D 모델의 커스텀 모델 트리를 생성하는 Windows Forms 애플리케이션입니다. 이 애플리케이션은 사용자가 커스텀 트리를 추가할 수 있도록 합니다.

## 주요 기능
- 3D 모델 파일 열기
- 커스텀 모델 트리 추가

## 사용법
1. **모델 오픈** 버튼을 클릭하여 3D 모델(*.vizx) 파일을 엽니다.
2. 추가된 커스텀 모델 트리를 확인합니다.

## 파일 구조
- `FrmMain.cs`: 메인 폼 파일로, UI 이벤트 핸들러와 VIZCore3DX.NET 제어 로직을 포함합니다.
- `Program.cs`: 애플리케이션의 진입점입니다.

## 요구 사항
- .NET Framework 4.8
- VIZCore3DX.NET 라이브러리