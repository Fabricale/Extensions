using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabricale.Extensions.Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
//[SimpleJob(RuntimeMoniker.Net472, baseline: true)]
//[SimpleJob(RuntimeMoniker.Net60)]
//[SimpleJob(RuntimeMoniker.Net70)]
//[SimpleJob(RuntimeMoniker.Net80)]
public class StringExtensionsBenchmarks
{
    [Params(100, 500, 5000, 10000)]
    public int WORDS;

    private const string STRING_100_WORDS = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat nisl. Quisque volutpat condimentum nisl, vel rutrum augue pellentesque a. Aliquam vel volutpat purus. Nunc laoreet, turpis a feugiat mollis, felis adipiscing volutpat orci, in pellentesque erat tortor a nibh. Sed molestie enim dapibus sodales fermentum. Nullam interdum sapien sed sodales finibus. Vestibulum id viverra adipiscing. Cras euismod nisi erat. Praesent in risus nunc. Quisque velit neque, rutrum nec ex in, efficitur maximus odio. Nam efficitur volutpat lacinia. In hac habitasse adipiscing dictumst. Sed volutpat vel metus vitae tincidunt. Nam pulvinar ante dui, a ultrices arcu sodales accumsan. adipiscing.";

    private string STRING_SEARCH_WORD = string.Empty;
    private string STRING_REPLACE_WORD = string.Empty;

    private string STRING_SEARCH_WORD_2 = string.Empty;
    private string STRING_REPLACE_WORD_2 = string.Empty;

    private string data = string.Empty;

    private readonly string[] testStringArray = new string[10];

    [GlobalSetup]
    public void Setup()
    {
        var iRepeat = WORDS / 100;

        var sb = new StringBuilder(iRepeat * STRING_100_WORDS.Length);

        for (int j = 1; j <= iRepeat; j++)
            sb.Append(STRING_100_WORDS);

        data = sb.ToString();

        STRING_SEARCH_WORD = "volutpat";
        STRING_REPLACE_WORD = "replacement";

        STRING_SEARCH_WORD_2 = "adipiscing";
        STRING_REPLACE_WORD_2 = "replacement2";
    }

    // ======================================================================
    // Test Using String.Replace()
    // ======================================================================

    [Benchmark]
    public void Test_StringReplace()
    {
        _ = data.Replace(STRING_SEARCH_WORD, STRING_REPLACE_WORD).Replace(STRING_SEARCH_WORD_2, STRING_REPLACE_WORD_2);
    }

    // ======================================================================
    // Test Using String.MultiReplace();
    // ======================================================================

    [Benchmark]
    public void Test_MultiReplace()
    {
        _ = data.MultiReplace(STRING_SEARCH_WORD, STRING_REPLACE_WORD, STRING_SEARCH_WORD_2, STRING_REPLACE_WORD_2);
    }
}
