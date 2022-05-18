using DATA.Abstract;
using ENTITIES.Concrete;
using SERVICES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(User datum)
        {
            try
            {
                await _unitOfWork.Users.AddAsync(datum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(x => x.Id == Id);
                if (user == null)
                    throw new Exception("Silenecek Kullanıcı Bulunamadı !");

                await _unitOfWork.Users.DeleteAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<User>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Users.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetAsync(Guid Id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(x => x.Id == Id);
                if (user == null)
                    throw new Exception("Gösterilecek Kullanıcı Bulunamadı !");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid> Login(string username, string password)
        {
            try
            {
                string hash = "";
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, password);
                }

                var users = await _unitOfWork.Users.GetAllAsync();
                var user = users.Where(x => x.UserName == username && x.Password == hash).FirstOrDefault();

                if (user == null)
                    throw new Exception("Kullanıcı adı/şifre hatalı !");

                Guid session = Guid.NewGuid();
                user.Session = session;

                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveAsync();

                return session;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(User datum)
        {
            try
            {
                var user = await _unitOfWork.Users.GetAsync(x => x.Id == datum.Id);
                if (user == null)
                    throw new Exception("Düzenlenecek Kullanıcı Bulunamadı !");

                user = datum;

                await _unitOfWork.Users.UpdateAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
