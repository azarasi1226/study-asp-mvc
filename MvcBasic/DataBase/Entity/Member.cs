﻿using MvcBasic.VIewModels.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.DataBase.Entity
{
    public class Member
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        [Required(ErrorMessage = "{0}は必須です")]
        [RegularExpression("[^a-z-A-Z0-9]*", ErrorMessage = "{0}には半角英数字を含めないでください。")]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください。")]
        public string Email { get; set; }

        [DisplayName("生年月日")]
        [Required(ErrorMessage = "{0}は必須です。")]
        public DateTime Birth { get; set; }

        [DisplayName("既婚")]
        public bool Married { get; set; }

        [DisplayName("自己紹介")]
        [Blackword("薬物,麻薬,毒,武器")]
        [StringLength(100, ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string Memo { get; set; }


        public static ValidationResult CheckBlackWord(string str)
        {
            string[] list = new[] { "毒", "麻薬", "武器", "違法" };

            foreach (var item in list)
            {
                if (str.Contains(item))
                {
                    return new ValidationResult("禁止ワードが含まれています");
                }
            }

            return ValidationResult.Success;
        }
    }
}