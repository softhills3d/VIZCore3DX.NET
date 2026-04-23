using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIZCore3DX.NET.Data;

namespace VIZCore3DX.NET.ModelComparison
{
    /// <summary>
    /// 두 모델(A/B)의 동일 노드에 대한 비교 결과를 담는 항목
    /// </summary>
    public class ModelComparisonItem
    {
        /// <summary>모델 A의 노드</summary>
        public Node Node1 { get; set; }
        /// <summary>모델 B의 노드</summary>
        public Node Node2 { get; set; }

        /// <summary>모델 A 노드의 바운딩 박스</summary>
        public BoundBox3D BBox1 { get; set; }
        /// <summary>모델 B 노드의 바운딩 박스</summary>
        public BoundBox3D BBox2 { get; set; }

        /// <summary>모델 A 노드의 메시 개수</summary>
        public ulong MeshCount1 { get; set; }
        /// <summary>모델 B 노드의 메시 개수</summary>
        public ulong MeshCount2 { get; set; }

        /// <summary>모델 A에 해당 노드가 존재하는지 여부</summary>
        public bool RESULT_EXIST_A { get; set; }
        /// <summary>모델 B에 해당 노드가 존재하는지 여부</summary>
        public bool RESULT_EXIST_B { get; set; }
        /// <summary>두 모델 모두에 해당 노드가 존재하는지 여부</summary>
        public bool RESULT_EXIST_BOTH { get; set; }
        /// <summary>두 노드의 위치(바운딩 박스)가 동일한지 여부</summary>
        public bool RESULT_LOCATION { get; set; }
        /// <summary>두 노드의 형상(메시 개수)이 동일한지 여부</summary>
        public bool RESULT_SHAPE { get; set; }

        /// <summary>
        /// ModelComparisonItem
        /// </summary>
        public ModelComparisonItem()
        {
            RESULT_EXIST_A = false;
            RESULT_EXIST_B = false;
            RESULT_EXIST_BOTH = false;
            RESULT_LOCATION = false;
            RESULT_SHAPE = false;
        }

        /// <summary>
        /// 두 노드의 위치 및 형상을 비교하여 결과를 설정한다.
        /// 양쪽 모델에 모두 노드가 존재할 때만 비교를 수행한다.
        /// </summary>
        public void Compare()
        {
            // 어느 한쪽이라도 노드가 없으면 비교 불가
            if (RESULT_EXIST_A == false) return;
            if (RESULT_EXIST_B == false) return;
            if (RESULT_EXIST_BOTH == false) return;

            // 바운딩 박스가 동일하면 위치 변경 없음
            if (BBox1 != null && BBox2 != null && BBox1.Equals(BBox2, false) == true)
                RESULT_LOCATION = true;

            // PART 노드는 메시 개수로 형상 동일 여부 판단
            if (Node1.Kind == NodeKind.PART)
            {
                if (MeshCount1 == MeshCount2)
                    RESULT_SHAPE = true;
            }
        }

        /// <summary>
        /// 두 노드가 동일한 모델인지 여부를 반환한다.
        /// 양쪽 모두 존재하고, 위치가 같으며, PART의 경우 형상도 같아야 true를 반환한다.
        /// </summary>
        public bool IsSameModel()
        {
            if (RESULT_EXIST_A == false) return false;
            if (RESULT_EXIST_B == false) return false;
            if (RESULT_EXIST_BOTH == false) return false;
            if (RESULT_LOCATION == false) return false;

            // PART가 아닌 노드(예: ASSEMBLY)는 위치만 같으면 동일로 판단
            if (Node1.Kind != NodeKind.PART) return true;

            // PART는 형상까지 동일해야 함
            if (RESULT_SHAPE == false) return false;

            return true;
        }
    }
}
