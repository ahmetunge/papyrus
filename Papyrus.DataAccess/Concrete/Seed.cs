using System;
using System.Collections.Generic;
using System.Linq;
using Papyrus.DataAccess.Concrete.EntityFramework;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete
{
    public class Seed
    {
        public static void SeedData(PapyrusContext context)
        {
            Ad badBlood = new Ad();
            Ad blueOceanShift = new Ad();
            Ad outliers = new Ad();
            Ad purpleCow = new Ad();
            Ad sapiens = new Ad();

            if (!context.Ads.Any())
            {
                badBlood.MemberId = new Guid("cd74470c-4ce7-4817-bce6-ff9c31d36cf4");
                badBlood.Title = "Bad Blood Book";
                badBlood.Description = "Cras lorem ligula, iaculis nec fermentum eu, vulputate eget sem. Nullam nunc dolor, facilisis eu vulputate nec, elementum dictum sem. Cras at augue turpis. Pellentesque malesuada accumsan arcu vitae convallis. Nunc sapien nunc, facilisis vel enim at, pharetra tincidunt orci. Aliquam et nisl mauris. Cras et elit erat. ";

                context.Ads.Add(badBlood);

                blueOceanShift.MemberId = new Guid("cd74470c-4ce7-4817-bce6-ff9c31d36cf4");
                blueOceanShift.Title = "New Blue Ocean Shift Book";
                blueOceanShift.Description = "Vestibulum vestibulum mi orci, at dignissim ligula consequat et. Aliquam ut ipsum aliquet, luctus urna sed, ultrices justo. Curabitur vel orci et turpis rhoncus blandit a sit amet tellus. Curabitur eleifend vulputate accumsan. Nullam nec justo risus. Pellentesque quis molestie lacus. Nunc vitae convallis leo, eu aliquam sapien. Nunc consequat ligula leo, ac interdum enim rutrum at. Pellentesque nec sem scelerisque velit cursus blandit ac vitae ipsum.";

                context.Ads.Add(blueOceanShift);

                outliers.MemberId = new Guid("cd74470c-4ce7-4817-bce6-ff9c31d36cf4");
                outliers.Title = "Free Outliers";
                outliers.Description = "Aenean at neque ultrices, lacinia ligula in, laoreet purus. Nulla lacinia sagittis arcu a sollicitudin. Fusce rutrum sem libero. Vestibulum in diam in libero dapibus consequat. Pellentesque iaculis iaculis sem vitae eleifend. Mauris vel suscipit justo. In a dapibus ex, in tincidunt sem.";

                context.Ads.Add(outliers);

                purpleCow.MemberId = new Guid("cd74470c-4ce7-4817-bce6-ff9c31d36cf4");
                purpleCow.Title = "Purple Cow";
                purpleCow.Description = "Vestibulum vestibulum mi orci, at dignissim ligula consequat et. Aliquam ut ipsum aliquet, luctus urna sed, ultrices justo. Curabitur vel orci et turpis rhoncus blandit a sit amet tellus. Curabitur eleifend vulputate accumsan. Nullam nec justo risus.";

                context.Ads.Add(purpleCow);

                sapiens.MemberId = new Guid("cd74470c-4ce7-4817-bce6-ff9c31d36cf4");
                sapiens.Title = "Sapiens";
                sapiens.Description = "Cras lorem ligula, iaculis nec fermentum eu, vulputate eget sem. Nullam nunc dolor, facilisis eu vulputate nec, elementum dictum sem. Cras at augue turpis. Pellentesque malesuada accumsan arcu vitae convallis. Nunc sapien nunc, facilisis vel enim at, pharetra tincidunt orci.";

                context.Ads.Add(sapiens);

                context.SaveChanges();
            }


              Category bookCategory = new Category();

            Category stationeryEquipmentCategory = new Category();

            if (!context.Categories.Any())
            {
                bookCategory.Name = "Book";
                bookCategory.Description = "Nunc in venenatis augue. Maecenas nec mauris rhoncus, sagittis orci in, posuere nisi. Cras ut mauris neque. Morbi rhoncus ipsum purus, quis gravida justo euismod eget. Ut viverra congue ante a consequat. Quisque ac nibh neque. Cras id orci placerat, vehicula turpis eget, malesuada orci. Suspendisse pretium mauris vel elit mollis bibendum. Mauris rutrum tellus eget imperdiet dignissim. Donec quis lacus venenatis, egestas lorem id, feugiat nisi. Nulla fringilla mi egestas arcu pretium bibendum.";


                stationeryEquipmentCategory.Name = "Stationery Equipment";
                stationeryEquipmentCategory.Description = "Suspendisse tincidunt nunc id dictum convallis. Sed eget nunc sem. Morbi rutrum interdum bibendum. Donec quis risus est. Integer euismod nibh neque, ut tempus nisl viverra ac. Phasellus sollicitudin et ex quis convallis. Suspendisse vel dolor vitae ligula dapibus sollicitudin ut eget nunc. Integer hendrerit accumsan massa nec porta. Mauris tempus eget nisl in malesuada.";

                context.Add(bookCategory);
                context.Add(stationeryEquipmentCategory);
                context.SaveChanges();
            }


            Product badBloodBook = new Product();

            Product purpleCowBook = new Product();

            Product blueOceanShiftBook = new Product();

            Product outliersBook = new Product();

            Product sapiensBook = new Product();

            if (!context.Products.Any())
            {
                purpleCowBook.AdId=purpleCow.Id;
                purpleCowBook.CategoryId=bookCategory.Id;
                purpleCowBook.Name="Purple Cow Book";
                context.Products.Add(purpleCowBook);

                badBloodBook.AdId=badBlood.Id;
                badBloodBook.CategoryId=bookCategory.Id;
                badBloodBook.Name="Bad Blood Book";
                context.Products.Add(badBloodBook);

                blueOceanShiftBook.AdId=blueOceanShift.Id;
                blueOceanShiftBook.CategoryId=bookCategory.Id;
                blueOceanShiftBook.Name="Blue Ocean Shift Book";
                context.Products.Add(blueOceanShiftBook);

                outliersBook.AdId=outliers.Id;
                outliersBook.CategoryId=bookCategory.Id;
                outliersBook.Name="Outliers Book";
                context.Products.Add(outliersBook);

                sapiensBook.AdId=sapiens.Id;
                sapiensBook.CategoryId=bookCategory.Id;
                sapiensBook.Name="Sapiens Book";
                context.Products.Add(sapiensBook);
                

                context.SaveChanges();
            
            }

        }
    }
}
