# VIZCore3DX.NET SectionBoxControl

## 개요
VIZCore3DX.NET SectionBoxControl 프로젝트는 VIZCore3DX.NET 라이브러리를 사용하여 3D 모델의 섹션 박스를 제어하는 Windows Forms 애플리케이션입니다. 이 애플리케이션은 사용자가 3D 모델을 로드하고, 섹션 박스를 추가, 표시, 숨기기, 재설정 및 크기 조정할 수 있도록 합니다.

## 주요 기능
- 3D 모델 파일 열기
- 섹션 박스 추가
- 섹션 박스 표시 및 숨기기
- 섹션 박스 크기 조정
- 섹션 박스 위치 이동
- 섹션 박스 재설정

## 사용법
1. **모델 오픈** 버튼을 클릭하여 3D 모델(*.vizx) 파일을 엽니다.
2. **Section Box Add** 버튼을 클릭하여 섹션 박스를 추가합니다.
3. **Section Box Show** 버튼을 클릭하여 섹션 박스를 표시합니다.
4. **Section Box Hide** 버튼을 클릭하여 섹션 박스를 숨깁니다.
5. **Section Box Reset** 버튼을 클릭하여 섹션 박스를 재설정합니다.
6. **Min/Max Resize** 버튼을 사용하여 섹션 박스의 크기를 조정합니다.
7. **Min/Max Move** 버튼을 사용하여 섹션 박스의 위치를 이동합니다.

## 파일 구조
- `Form1.cs`: 메인 폼 파일로, UI 이벤트 핸들러와 VIZCore3DX.NET 제어 로직을 포함합니다.
- `Program.cs`: 애플리케이션의 진입점입니다.
- `App.config`: 애플리케이션 설정 파일입니다.

## 요구 사항
- .NET Framework 4.8
- VIZCore3DX.NET 라이브러리
