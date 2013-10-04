using Xunit;
using Should;

namespace AutoMapper.UnitTests.Bug
{
    public class NullablePropertiesBug
    {
        public class Source { public int? A { get; set; } }
        public class Target { public int? A { get; set; } }

        [Fact]
        public void Example()
        {
            Mapper.CreateMap<Source, Target>();

            var d = Mapper.Map(new Source { A = null }, new Target { A = 10 });

            d.A.ShouldBeNull();
        }
    }

    public class Int_to_NullableDecimal_Bug
    {
        public class Source { public int A { get; set; } }
        public class Target { public decimal? A { get; set; } }

        public Int_to_NullableDecimal_Bug()
        {
            Mapper.CreateMap<Source, Target>();
        }

        [Fact]
        public void ConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void MapsCorrectly()
        {
            var target = Mapper.Map<Source, Target>(new Source { A = 25 });
            target.A.ShouldEqual(25.0m);
        }
    }
}