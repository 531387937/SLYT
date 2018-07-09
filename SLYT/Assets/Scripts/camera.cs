using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class camera : MonoBehaviour
{



        public Material Mat; public float BlurSize = 10;
        public int interator = 2;
        [Range(0, 1)]
        public float FocusDistance = 0.5f;
        [Range(0, 0.5f)]
        public float FocusRange = 0.1f;

        void OnEnable()
        {
            GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
        }
        void OnDisable()
        {
            GetComponent<Camera>().depthTextureMode = ~DepthTextureMode.Depth;
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            var w = src.width / 8;
            var h = src.height / 8;
            var tmp1 = RenderTexture.GetTemporary(w, h);
            var tmp2 = RenderTexture.GetTemporary(w, h);
            Mat.SetFloat("_BlurSize", BlurSize);
            Mat.SetFloat("_FocusDistance", FocusDistance);
            Mat.SetFloat("_FocusRange", FocusRange);

            Graphics.Blit(src, tmp1);

            for (int i = 0; i < interator; i++)
            {
                Graphics.Blit(tmp1, tmp2, Mat, 0);
                Graphics.Blit(tmp2, tmp1, Mat, 1);
            }

            Mat.SetTexture("_BlurTex", tmp1);

            Graphics.Blit(src, dest, Mat, 2);

            RenderTexture.ReleaseTemporary(tmp1);
            RenderTexture.ReleaseTemporary(tmp2);

        } }

