using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DataManager : MonoBehaviour
{
    // ����WebGL�ł̏ꍇ�́AJavaScript���œ����֐����擾����
    // addData �� 1���s���Ƃ�js�Ƀf�[�^�𑗐M����֐�
    // downloadData �� �C�ӂ̎��s���I������̂��Acsv�f�[�^���_�E�����[�h����֐�
#if UNITY_WEBGL && !UNITY_EDITOR
     [DllImport("__Internal")]
     private static extern void addData(string jsonData);
 
     [DllImport("__Internal")]
     private static extern void downloadData();
#endif

    // �擾����f�[�^�̃N���X���`
    // Escape-Fish�̏ꍇ�́u�X�R�Ascore�v�u�l�������v�u�_���[�W���v
    [System.Serializable]
    public class Data
    {
        public int score;
        public int getFish;
        public float pressButtonMany;
    }

    // ���s���I������Ƃ��ɌĂяo���֐�
    // Hunter-Chameleon�ł́A�Q�[���I���̂Ƃ��Ɂu�X�R�A�v�u�q�b�g���v�u�g���K�[�����������v�������Ƃ��Ă��̊֐����Ăяo���Ă��܂�
    // �Q�[���ɉ����ĕ�����₷���ϐ����ɂ��Ă�������
    public void postData(int _score, int _get_Fish, int _pressButtonMany)
    {
        Data data = new Data(); // �N���X�𐶐�
        data.score = _score; // �X�R�A
        data.getFish = _get_Fish; // �q�b�g��
        data.pressButtonMany = _pressButtonMany; // �q�b�g��
        string json = JsonUtility.ToJson(data); // json�`���ɕϊ�����js�ɓn��
#if UNITY_WEBGL && !UNITY_EDITOR
        addData(json);
#endif
    }

    // �_�E�����[�h�{�^�����������Ƃ��ɌĂяo���֐�
    public void getData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
         downloadData();
#endif
    }
}