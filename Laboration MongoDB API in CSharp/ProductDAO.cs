namespace Laboration_MongoDB_API_in_CSharp;

internal interface ProductDAO
{
    void CreateOne();
    List<Entries> ReadAll();
    void UpdateOne ();
    void DeleteOne ();
}