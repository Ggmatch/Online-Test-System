using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class QuestionBankRepository : IQuestionBankRepository
    {
        DBEntities2 db;

        public QuestionBankRepository()
        {
            db = new DBEntities2();
        }

        public trueorfalse Add1(int id, trueorfalse question)
        {
            // 向试题表里增加试题
            question = db.trueorfalse.Add(question);
            include_question_between_bank_and_trueorfalse tmp = new include_question_between_bank_and_trueorfalse
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_trueorfalse.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public completion Add2(int id, completion question)
        {
            // 向试题表里增加试题
            question = db.completion.Add(question);
            include_question_between_bank_and_completion tmp = new include_question_between_bank_and_completion
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_completion.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public selection Add3(int id, selection question)
        {
            // 向试题表里增加试题
            question = db.selection.Add(question);
            include_question_between_bank_and_selection tmp = new include_question_between_bank_and_selection
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_selection.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public questionandanswer Add4(int id, questionandanswer question)
        {
            // 向试题表里增加试题
            question = db.questionandanswer.Add(question);
            include_question_between_bank_and_questionandanswer tmp = new include_question_between_bank_and_questionandanswer
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_questionandanswer.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public reading Add5(int id, reading question)
        {
            // 向试题表里增加试题
            question = db.reading.Add(question);
            include_question_between_bank_and_reading tmp = new include_question_between_bank_and_reading
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_reading.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public composition Add6(int id, composition question)
        {
            // 向试题表里增加试题
            question = db.composition.Add(question);
            include_question_between_bank_and_composition tmp = new include_question_between_bank_and_composition
            {
                BankID = id,
                QuestionID = question.ID
            };
            // 向题库里增加试题
            db.include_question_between_bank_and_composition.Add(tmp);
            db.SaveChanges();
            return question;
        }

        public bool Binding(int id, int type)
        {
            binding_typeofwork_between_questionbank_and_typeofwork tmp = new binding_typeofwork_between_questionbank_and_typeofwork
            {
                IDOfQuestionBank = id,
                IDOfTypeOfWork = type
            };
            db.binding_typeofwork_between_questionbank_and_typeofwork.Add(tmp);
            db.SaveChanges();
            return true;
        }

        public int Count(int id)
        {
            int c1 = db.include_question_between_bank_and_trueorfalse.Where(p => p.BankID == id).Count();
            int c2 = db.include_question_between_bank_and_completion.Where(p => p.BankID == id).Count();
            int c3 = db.include_question_between_bank_and_selection.Where(p => p.BankID == id).Count();
            int c4 = db.include_question_between_bank_and_questionandanswer.Where(p => p.BankID == id).Count();
            int c5 = db.include_question_between_bank_and_reading.Where(p => p.BankID == id).Count();
            int c6 = db.include_question_between_bank_and_composition.Where(p => p.BankID == id).Count();
            return c1 + c2 + c3 + c4 + c5 + c6;
        }

        public bool Delete1(int id, int QuestionID)
        {
            include_question_between_bank_and_trueorfalse tmp;
            // 删除题库中的试题
            tmp = db.include_question_between_bank_and_trueorfalse.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_trueorfalse.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_bank_and_trueorfalse.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_bank_and_trueorfalse.Remove(i);
            // 删除试题
            trueorfalse tmp1;
            tmp1 = db.trueorfalse.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.trueorfalse.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public bool Delete2(int id, int QuestionID)
        {
            include_question_between_bank_and_completion tmp;
            // 删除题库中的试题
            tmp = db.include_question_between_bank_and_completion.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_completion.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_bank_and_completion.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_bank_and_completion.Remove(i);
            // 删除试题
            completion tmp1;
            tmp1 = db.completion.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.completion.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public bool Delete3(int id, int QuestionID)
        {
            include_question_between_bank_and_selection tmp;
            // 删除题库中的试题
            tmp = db.include_question_between_bank_and_selection.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_selection.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_testpaper_and_selection.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_testpaper_and_selection.Remove(i);
            // 删除试题
            selection tmp1;
            tmp1 = db.selection.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.selection.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public bool Delete4(int id, int QuestionID)
        {
            include_question_between_bank_and_questionandanswer tmp;
            // 删除题库中的试题
            tmp = db.include_question_between_bank_and_questionandanswer.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_questionandanswer.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_testpaper_and_questionandanswer.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_testpaper_and_questionandanswer.Remove(i);
            // 删除试题
            questionandanswer tmp1;
            tmp1 = db.questionandanswer.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.questionandanswer.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public bool Delete5(int id, int QuestionID)
        {
            include_question_between_bank_and_reading tmp;
            // 删除题库中的试题
            tmp = db.include_question_between_bank_and_reading.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_reading.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_testpaper_and_reading.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_testpaper_and_reading.Remove(i);
            // 删除试题
            reading tmp1;
            tmp1 = db.reading.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.reading.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public bool Delete6(int id, int QuestionID)
        {
            // 解除题库与试题的关系
            var tmp = db.include_question_between_bank_and_composition.Where(p => p.BankID == id && p.QuestionID == QuestionID).FirstOrDefault();
            db.include_question_between_bank_and_composition.Remove(tmp);
            // 解除试卷与试题的关系
            var result = db.include_question_between_testpaper_and_composition.Where(p => p.QuestionID == QuestionID);
            foreach (var i in result)
                db.include_question_between_testpaper_and_composition.Remove(i);
            // 删除试题
            composition tmp1;
            tmp1 = db.composition.Where(p => p.ID == QuestionID).FirstOrDefault();
            db.composition.Remove(tmp1);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<trueorfalse> Get1(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.trueorfalse
                        where (
                        from t1 in db.include_question_between_bank_and_trueorfalse
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public IEnumerable<completion> Get2(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.completion
                        where (
                        from t1 in db.include_question_between_bank_and_completion
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public IEnumerable<selection> Get3(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.selection
                        where (
                        from t1 in db.include_question_between_bank_and_selection
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public IEnumerable<questionandanswer> Get4(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.questionandanswer
                        where (
                        from t1 in db.include_question_between_bank_and_questionandanswer
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public IEnumerable<reading> Get5(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.reading
                        where (
                        from t1 in db.include_question_between_bank_and_reading
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public IEnumerable<composition> Get6(int id)
        {
            // 先到题库中找试题编号，然后到试题表中找试题
            var query = from t in db.composition
                        where (
                        from t1 in db.include_question_between_bank_and_composition
                        where t1.BankID == id
                        select t1.QuestionID
                               ).Contains(t.ID)
                        select t;
            return query;
        }

        public bool Update1(int id, trueorfalse question)
        {
            trueorfalse tmp = db.trueorfalse.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.Answer = question.Answer;
                tmp.Score = question.Score;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update2(int id, completion question)
        {
            completion tmp = db.completion.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.Answer = question.Answer;
                tmp.Score = question.Score;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update3(int id, selection question)
        {
            selection tmp = db.selection.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.OptionA = question.OptionA;
                tmp.OptionB = question.OptionB;
                tmp.OptionC = question.OptionC;
                tmp.OptionD = question.OptionD;
                tmp.Answer = question.Answer;
                tmp.Score = question.Score;
                tmp.Type = question.Type;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update4(int id, questionandanswer question)
        {
            questionandanswer tmp = db.questionandanswer.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.Answer = question.Answer;
                tmp.Score = question.Score;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update5(int id, reading question)
        {
            reading tmp = db.reading.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.QuestionA = question.QuestionA;
                tmp.QuestionB = question.QuestionB;
                tmp.QuestionC = question.QuestionC;
                tmp.Answer1 = question.Answer1;
                tmp.Answer2 = question.Answer2;
                tmp.Answer3 = question.Answer3;
                tmp.Score1 = question.Score1;
                tmp.Score2 = question.Score2;
                tmp.Score3 = question.Score3;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update6(int id, composition question)
        {
            composition tmp = db.composition.Where(p => p.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                // 修改
                tmp.Content = question.Content;
                tmp.Answer = question.Answer;
                tmp.Score = question.Score;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}