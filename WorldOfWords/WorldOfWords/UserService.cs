using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace WorldOfWords
{
    class UserService
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private string Hash(string password, int iterations = 10000)
        { 
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            var hash_bytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hash_bytes, 0, SaltSize);
            Array.Copy(hash, 0, hash_bytes, SaltSize, HashSize);
            var base64_hash = Convert.ToBase64String(hash_bytes);
            return string.Format("$MYHASH$V1${0}${1}", iterations, base64_hash);
        }

        private bool IsHashSupported(string hash_string)
        {
            return hash_string.Contains("$MYHASH$V1$");
        }
        private bool Verify(string password, string hashed_password)
        {
            if (!IsHashSupported(hashed_password))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }
            var splitted_hash_string = hashed_password.Replace("$MYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splitted_hash_string[0]);
            var base64_hash = splitted_hash_string[1];
            var hash_bytes = Convert.FromBase64String(base64_hash);
            var salt = new byte[SaltSize];
            Array.Copy(hash_bytes, 0, salt, 0, SaltSize);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);
            for (var i = 0; i < HashSize; i++)
            {
                if (hash_bytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidName(string s)
        {
            Regex regex = new Regex(@"^[a-z]+$");
            s = s.ToLower();
            if (regex.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        private bool ValidEmail(string s)
        {
            Regex regex = new Regex(@"^.+@.+\..+$");
            if (regex.IsMatch(s))
            {
                return true;
            }
            return false;
        }

        private bool ValidPassword(string s)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
            if (regex.IsMatch(s))
            {
                return true;
            }
            return false;
        }
        public bool AddUser(string fullName, string email, string password)
        {
            bool IsValidName = ValidName(fullName);
            bool isValidEmail = ValidEmail(email);
            bool isValidPassword = ValidPassword(password);
            if (isValidEmail && isValidPassword && IsValidName)
            {
                using (WorldOfWordsContext db = new WorldOfWordsContext())
                {
                    try
                    {
                        User new_user = new User { FullName = fullName, Email = email, Password = Hash(password)};
                        db.User.Add(new_user);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("This email already taken!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
<<<<<<< Updated upstream
=======
            else
            {
                if (!isValidEmail)
                {
                    MessageBox.Show("Invalid email!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                if (!IsValidName)
                {
                    MessageBox.Show("Invalid name!", "Error!",  MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                if (!isValidPassword)
                {
                    MessageBox.Show("Password must contains minimun 8 character, lowercase, capital letter and special symbol!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return false;
            }
>>>>>>> Stashed changes
        }

        public int VerifyUser(string email, string password)
        {
            using (WorldOfWordsContext db = new WorldOfWordsContext())
            {
                try
                {
                    User record = db.User.Single(user => (user.Email == email) && Verify(password, user.Password));
                    return record.Id;
                }
                catch (Exception e)
                {
                    // Console.WriteLine("Exception thrown {0}", e.Message);
                    return -1;
                }
            }
        }
    }
}
