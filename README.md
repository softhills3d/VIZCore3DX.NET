# VIZCore3DX.NET

VIZCore3DX.NET 라이브러리를 활용한 Windows Forms 예제 프로젝트 모음입니다.

## 요구 사항
- .NET Framework 4.8
- VIZCore3DX.NET 라이브러리

## WinForms 예제 프로젝트
### 기본 / 뷰어
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.App** | VIZCore3DX.NET의 기본 뷰어 동작을 확인하는 예제 |
| **VIZCore3DX.NET.Demo** | VIZCore3DX.NET의 다양한 기능을 데모 형태로 시연하는 예제 |
| **VIZCore3DX.NET.ToolbarHide** | VIZCore3DX.NET 뷰어의 툴바 항목을 표시하거나 숨기는 예제 |
| **VIZCore3DX.NET.Frame** | Frame 예제 |
| **VIZCore3DX.NET.Recording** | 3D 뷰 화면을 녹화하여 동영상으로 저장하는 예제 (FFMpeg 필요) |

### 모델 구조 / 속성
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Structure** | 모델을 로드하지 않은 상태에서 파일 구조와 선택한 노드의 속성 정보를 조회하는 예제 |
| **VIZCore3DX.NET.CustomModelTree** | 모델의 노드 구조를 사용자 정의 트리 형태로 조회하고 관리하는 예제 |
| **VIZCore3DX.NET.NodeDetail** | 선택한 노드의 색상, 투명도, 이동, 회전, UDA 및 형상 정보를 조회하는 예제 |
| **VIZCore3DX.NET.NodeVisibleChanged** | 모델 노드의 가시성 변경을 감지하고 관련 이벤트를 처리하는 예제 |
| **VIZCore3DX.NET.GeometryProperty** | 모델의 중심점, 크기, 부피 등 기하학 속성을 조회하는 예제 |
| **VIZCore3DX.NET.MeshCount** | 모델의 노드별 메시 개수와 형상 정보를 조회하는 예제 |
| **VIZCore3DX.NET.UDA** | 사용자가 선택한 모델 객체에 등록된 사용자 정의 속성 정보를 조회하는 예제 |
| **VIZCore3DX.NET.ImportAttribute** | 외부 속성 파일을 불러와 각 모델 노드에 속성 정보를 연결하는 예제 |
| **VIZCore3DX.NET.SplitObjects** | 모델 객체를 조건에 따라 분리하고 개별 객체로 관리하는 예제 |

### 카메라 / 뷰
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Camera.CCTV** | CCTV 카메라 위치를 설정하고 자동으로 회전시키는 예제 |
| **VIZCore3DX.NET.CameraControl** | 카메라 위치, 시점, 확대 및 축소를 제어하는 예제 |
| **VIZCore3DX.NET.CameraDataSaver** | 3D 모델의 카메라 데이터를 저장하고 로드하여 동일한 뷰를 재현하는 예제 |
| **VIZCore3DX.NET.MiniView** | 선택하거나 지정한 객체를 별도의 미니뷰에서 조회하는 예제 |
| **VIZCore3DX.NET.ChildView** | 자식 뷰를 생성하고 모델 표시 화면을 관리하는 예제 |
| **VIZCore3DX.NET.UserView** | 사용자가 지정한 카메라 뷰를 저장하고 다시 불러오는 예제 |

### 검색 / 선택
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Search** | 키워드를 사용하여 3D 모델의 노드를 검색하는 예제 |
| **VIZCore3DX.NET.SearchSpace** | 지정한 공간 범위에 포함된 모델 객체를 검색하고 조회하는 예제 |
| **VIZCore3DX.NET.SpaceSearch** | 특정 공간 영역에 포함되거나 겹치는 모델 객체를 검색하는 예제 |
| **VIZCore3DX.NET.SelectByBox_IncludeAssembly** | 박스 선택으로 Part를 선택하고 상위 Assembly까지 포함하여 선택하는 예제 |
| **VIZCore3DX.NET.SelectParentAssembly** | 3D 형상을 선택하여 해당 객체의 상위 Assembly 노드를 조회하고 선택하는 예제 |
| **VIZCore3DX.NET.ZoneObjects** | 3D 공간을 특정 구역으로 구분하고 구역에 포함된 객체를 조회하는 예제 |

### 그룹 / 색상
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Group** | 선택한 객체를 그룹으로 생성하고 조회 및 관리하는 예제 |
| **VIZCore3DX.NET.Painting** | 선택한 모델 노드의 색상을 변경하고 적용 결과를 확인하는 예제 |

### 노트 / 리뷰
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Note** | 2D, 3D 및 표면 노트를 생성하고 관리하는 예제 |
| **VIZCore3DX.NET.Note.V2** | 3D 공간에 다양한 유형의 노트를 추가하고 상태를 관리하는 예제 |
| **VIZCore3DX.NET.NoteTransform** | 노트의 위치, 회전 및 크기 변환을 수행하고 결과를 확인하는 예제 |
| **VIZCore3DX.NET.MeetingNotes** | 3D 모델에 회의용 노트와 주석을 추가하고 관리하는 예제 |
| **VIZCore3DX.NET.Snapshot** | 스냅샷을 생성, 복원하고 JSON 파일로 내보내기/가져오기하는 예제 |

### 측정 / 단면
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.MeasureFrame** | 프레임 좌표계를 기준으로 모델 간 거리와 위치를 측정하는 예제 |
| **VIZCore3DX.NET.SectionAutoClip** | 선택한 객체의 경계 영역을 기준으로 단면을 자동 생성하는 예제 |
| **VIZCore3DX.NET.SectionBoxControl** | 섹션 박스를 추가, 표시, 숨기기, 크기 조정, 위치 이동하는 예제 |
| **VIZCore3DX.NET.SectionBoxSize** | 섹션 박스의 크기와 위치를 세밀하게 조정하는 예제 |
| **VIZCore3DX.NET.SectionMoveByOsnap** | Osnap으로 선택한 위치를 기준으로 단면의 위치를 이동하는 예제 |

### 간섭 검사 / 충돌
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.ClashTest** | 3D 모델의 간섭(Clash) 검사를 수행하고 결과를 확인하는 예제 |
| **VIZCore3DX.NET.ClashTest_MoveTest** | 3D 모델의 이동 간섭 검사(Clash Move Test)를 수행하고 결과를 확인하는 예제 |

### 모델 비교 / 분석
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.ModelComparison** | 두 개의 3D 모델을 열어 구조, 위치, 형상 및 차이점을 비교하는 예제 |

### 애니메이션 / 시뮬레이션
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Animation** | Animation API 를 사용하여 크레인으로 탱크를 이동시키는 예제. (크레인 모델 파일 포함) |
| **VIZCore3DX.NET.Explode** | 모델의 어셈블리와 부품을 단계적으로 분해하여 표시하는 예제 |

### 변환 / 회전 / 이동
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.CustomAxisRotation** | 사용자가 지정한 축을 기준으로 모델을 회전시키는 예제 |
| **VIZCore3DX.NET.RotateModel** | 변환 행렬을 이용하여 모델의 위치와 회전을 변경하는 예제 |

### 투영 / 2D
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Projection2D** | 3D 모델의 외곽 형상을 2D로 투영하고 결과를 확인하는 예제 |

### 이미지 / 썸네일
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Capture3D** | 3D 모델과 미니뷰를 함께 이미지로 캡처하는 예제 |
| **VIZCore3DX.NET.CaptureImage** | 3D 뷰 화면을 이미지로 캡처하고 저장하는 예제 |
| **VIZCore3DX.NET.GenerateThumbnail** | 여러 모델 파일의 썸네일을 생성하고 목록에서 확인하는 예제 |

### 내보내기 / 변환
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.ExportNode** | 선택한 노드 또는 전체 모델 데이터를 파일로 저장하고 내보내는 예제 |
| **VIZCore3DX.NET.VIZXtoVIZ** | VIZX 파일을 VIZ 파일로 변환하는 예제 (VIZXMigration.exe 필요) |

### 프레임
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.FramePrefix** | 프레임 좌표를 기준으로 객체에 접두어 정보를 설정하는 예제 |

### 그리드 / 좌표
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.GridThreeD** | 모델을 그리드 단위로 분할하고 내보내기, 상세 보기 및 분해 표시를 수행하는 예제 |
| **VIZCore3DX.NET.GridThreeD.V2** | 특정 노드를 축 기준으로 회전하고 그리드 기반 공간을 분석하는 예제 |

### 객체 스냅
| 프로젝트 | 설명 |
|---|---|
| **VIZCore3DX.NET.Osnap** | 모델의 면, 점, 선 및 원 형상을 스냅 방식으로 선택하고 위치와 형상 정보를 확인하는 예제 |
| **VIZCore3DX.NET.Osnap2DPoint** | Osnap으로 선택한 3D 위치를 화면의 2D 좌표로 변환하고 확인하는 예제 |