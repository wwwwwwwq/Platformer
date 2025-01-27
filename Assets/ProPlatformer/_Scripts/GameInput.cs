﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Myd.Platform
{
    public enum Facings
    {
        Right = 1,
        Left = -1
    }

    public struct VirtualIntegerAxis
    {

    }
    public struct VirtualJoystick
    {
        public Vector2 Value { get => new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical")); }
    }
    public struct VisualButton
    {
        public KeyCode key;
        private float bufferTime;
        private bool consumed;
        private float bufferCounter;
        public VisualButton(KeyCode key) : this(key, 0)
        {
        }

        public VisualButton(KeyCode key, float bufferTime)
        {
            this.key = key;
            this.bufferTime = bufferTime;
            this.consumed = false;
            this.bufferCounter = 0f;
        }
        public void ConsumeBuffer()
        {
            this.bufferCounter = 0f;
        }

        public bool Pressed()
        {
            return UnityEngine.Input.GetKeyDown(key) || (!this.consumed && (this.bufferCounter > 0f));
        }

        public bool Checked()
        {
            return UnityEngine.Input.GetKey(key);
        }

        public void Update(float deltaTime)
        {
            this.consumed = false;
            this.bufferCounter -= deltaTime;
            bool flag = false;
            if (UnityEngine.Input.GetKeyDown(key))
            {
                this.bufferCounter = this.bufferTime;
                flag = true;
            }
            else if (UnityEngine.Input.GetKey(key))
            {
                flag = true;
            }
            if (!flag)
            {
                this.bufferCounter = 0f;
                return;
            }
        }
    }
    public static class GameInput
    {
        public static VisualButton Jump = new VisualButton(KeyCode.Space, 0.08f);
        public static VisualButton Dash = new VisualButton(KeyCode.None, 0.08f);
        public static VisualButton Grab = new VisualButton(KeyCode.K);
        public static VirtualJoystick Aim = new VirtualJoystick();
        public static Vector2 LastAim;

        //根据当前朝向,决定移动方向.
        public static Vector2 GetAimVector(Facings defaultFacing = Facings.Right)
        {
            Vector2 value = GameInput.Aim.Value;
            //TODO 考虑辅助模式

            //TODO 考虑摇杆
            if (value == Vector2.zero)
            {
                GameInput.LastAim = Vector2.right * ((int)defaultFacing);
            }
            else
            {
                GameInput.LastAim = value;
            }
            return GameInput.LastAim.normalized;
        }

        public static void Update(float deltaTime)
        {
            Jump.Update(deltaTime);
            Dash.Update(deltaTime);
        }
    }




}
