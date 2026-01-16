# VIZCore3DX.NET.Recording

## 개요
`VIZCore3DX.NET.Recording` 프로젝트는 VIZCore3DX.NET 라이브러리를 사용하여 3D뷰 섹션의 화면을 녹화하는 Windows Forms 애플리케이션입니다. 이 애플리케이션은 사용자가 보고있는 3D 모델의 화면을 녹화할 수 있게 합니다.

## 주요 기능
- 3D 모델 파일 열기
- ffmpeg.exe 경로 지정
- output 파일 경로 지정
- 마우스 커서 녹화 유무 지정
- 화면 녹화 시작
- 화면 녹화 정지

## 사용법
1. **모델 오픈** 버튼을 클릭하여 3D 모델(*.vizx) 파일을 엽니다.
2. **경로 미리 지정** 체크박스로 경로를 미리 지정할지 선택합니다.
(체크 시) ffmpeg.exe와 output.mp4의 경로를 사전에 지정합니다.
(해제 시) 녹화버튼을 클릭하면 경로를 지정합니다.
3. **ShowCursor** 체크박스로 마우스커서를 보이게할지 선택합니다.
4. **Start**버튼을 클릭하여 녹화를 시작합니다.
5. **Stop**버튼을 클릭하여 녹화를 종료합니다.


## 파일 구조
- `FrmMain.cs`: 메인 폼 파일로, UI 이벤트 핸들러와 VIZCore3DX.NET 제어 로직을 포함합니다.
- `Program.cs`: 애플리케이션의 진입점입니다.

## 요구 사항
- .NET Framework 4.8
- VIZCore3DX.NET 라이브러리
- FFMpeg 화면 녹화 솔루션

## FFMpeg 다운로드 방법
- 사이트 : https://www.gyan.dev/ffmpeg/builds/
- release builds 섹션
- ffmpeg-release-essentials.7z 파일 다운로드