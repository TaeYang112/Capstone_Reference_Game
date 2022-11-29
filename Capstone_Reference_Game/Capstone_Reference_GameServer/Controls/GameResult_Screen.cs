﻿using Capstone_Referecne_GameServer;
using Capstone_Reference_Game_Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_GameServer.Controls
{
    public partial class GameResult_Screen : UserControl
    {
        // 제출자 수
        private int submitterCount = 0;

        // 정답자 수
        private int correctAnswerCount = 0;

        GameServerForm serverForm;
        public GameResult_Screen(GameServerForm serverForm)
        {
            InitializeComponent();
            this.serverForm = serverForm;
        }

        private void btn_GameStop_Click(object sender, EventArgs e)
        {
            MessageGenerator generator = new MessageGenerator(Protocols.S_GAME_END);
            serverForm.GameServerManager.SendMessageToAll(generator.Generate());
        }

        public void AddResult(string studentId, int answer)
        {
            GameConfiguration config = serverForm.GameServerManager.Configuration;
            submitterCount++;

            string strAnswer = "";
            string AnswerCheck = "";
            if(config.QuizType == QuizTypes.OX_QUIZ)
            {
                switch(answer)
                {
                    case 1: strAnswer = "O";
                        break;
                    case 2: strAnswer = "X";
                        break;
                    default: strAnswer = "무응답";
                        break;
                }
            }
            else
            {
                if (answer == -1) strAnswer = "무응답";
                else strAnswer = answer.ToString();
            }

            if(1 == answer)
            {
                AnswerCheck = "정답";
                correctAnswerCount++;
            }
            Invoke(new Action(() => {
                // 그리드 뷰에 추가
                grid_Result.Rows.Add(studentId, strAnswer,AnswerCheck);

                // 그리드 정렬
                grid_Result.Sort(grid_Result.Columns[2], ListSortDirection.Descending);

                // 제출자, 정답자, 정답률 텍스트 변경
                lbl_submitter.Text = submitterCount + "명";
                lbl_CorrectAnswer.Text = correctAnswerCount + "명";
                lbl_AnswerPercent.Text = Math.Round((float)correctAnswerCount / submitterCount * 100) + "%";

            }));
            
        }
    }
}