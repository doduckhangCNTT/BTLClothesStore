using BTL_ClothesStore.Constants;
using Microsoft.AspNetCore.Identity;

namespace BTL_ClothesStore.Data
{
    public class DbSeeder
    {
        /*
         - Mục đích của DbSeeder là để đăng kí 1 tài khoản Admin
         */
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>(); // -> Quản lí người dùng
            var roleMgr = service.GetService<RoleManager<IdentityRole>>(); // -> Quản lí roles

            // Them cac role
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };

            // Kiem tra email admin này đã tồn tại chưa
            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                // Tạp tài khoản Admin và thêm quyền cho Admin
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
